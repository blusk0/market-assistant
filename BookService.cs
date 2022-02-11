using MarketAssistant.Data;
using MarketAssistant.IBusiness;
using MarketAssistant.Models.Data;
using MarketAssistant.Models.Dto;
using MarketAssistant.Models.Web;
using Microsoft.EntityFrameworkCore;

namespace MarketAssistant.Business;

public class BookService : IBookService
{
    private readonly MarketContext _context;

    public BookService(MarketContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookDto>> ReadByIds(string ids, string hostUrl)
    {
        List<int> bookIds = ids.Split(',').Select(t =>int.Parse(t)).ToList();
        var bookQuery = ReadAllQuery()
                       .Where(t => bookIds.Contains(t.Id));
        return new BookDto().AdaptMany(await bookQuery.ToListAsync(), hostUrl);
    }

    public async Task<IEnumerable<BookDto>> ReadAll(string hostUrl)
    {
        return new BookDto().AdaptMany(await ReadAllQuery().ToListAsync(), hostUrl);
    }

    public async Task<IEnumerable<BookDto>> ReadAllWithinRange(string hostUrl, DateTime? startDate = null, DateTime? endDate = null)
    {
        var bookQuery = ReadAllQuery();
        if (startDate.HasValue)
        {
            bookQuery = bookQuery.Where(t => t.PublishDate >= startDate.Value);
        }
        if (endDate.HasValue)
        {
            bookQuery = bookQuery.Where(t => t.PublishDate <= endDate.Value);
        }

        return new BookDto().AdaptMany(await bookQuery.ToListAsync(), hostUrl);
    }

    public async Task<IEnumerable<BookDto>> ReadAllByAuthor(int authorId, string hostUrl)
    {
        var books = await ReadAllQuery()
            .Where(t => t.AuthorId == authorId)
            .ToListAsync();

        return books.Any() ? new BookDto().AdaptMany(books, hostUrl) : new List<BookDto>();
    }

    public async Task<IEnumerable<MarketerAssignmentDto>> GetMarketerAssignments(int bookId, string hostUrl)
    {
        var assignments = await _context.MarketerAssignments
            .AsNoTracking()
            .Where(t => t.BookId == bookId)
            .Include(t => t.Marketer)
            .ToListAsync();

        return new MarketerAssignmentDto().AdaptMany(assignments, hostUrl);
    }

    public async Task<IEnumerable<BookDto>> ReadBooksWithNoAssignments(string hostUrl)
    {
        var books = await ReadAllQuery()
            .Where(t => !t.MarketerAssignments.Any(t => t.UnassignedDt == null))
            .ToListAsync();

        return new BookDto().AdaptMany(books, hostUrl);
    }

    public async Task<ChartBreakdown> ReadBookChartBreakdown()
    {
        var books = await ReadAll("");

        return new ChartBreakdown
        {
            NoCoverage = new ChartTitleItem
            {
                Name = "No Coverage",
                TitleIds = books.Where(t => !t.Events.Any() && !t.MarketerAssignments.Any(t => t.UnassignedDt == null) && !t.MarketMaterials.Any()).Select(t => t.Id).ToList()
            },
            NoEvents = new ChartTitleItem
            {
                Name = "No Events",
                TitleIds = books.Where(t => !t.Events.Any()).Select(t => t.Id).ToList()
            },
            NoMarketer = new ChartTitleItem
            {
                Name = "No Marketer",
                TitleIds = books.Where(t => !t.MarketerAssignments.Any(t => t.UnassignedDt == null)).Select(t => t.Id).ToList()
            },
            NoMaterials = new ChartTitleItem
            {
                Name = "No Materials",
                TitleIds = books.Where(t => !t.MarketMaterials.Any()).Select(t => t.Id).ToList()
            },
            FullyCovered = new ChartTitleItem
            {
                Name = "Fully Covered",
                TitleIds = books.Where(t => t.Events.Any() && t.MarketerAssignments.Any(t => t.UnassignedDt == null) && t.MarketMaterials.Any()).Select(t => t.Id).ToList()
            }
        };
    }

    private IQueryable<Book> ReadAllQuery()
    {
        return from book in _context.Books.AsNoTracking()
               select new Book
               {
                   Id = book.Id,
                   Author = _context.Authors.First(t => t.Id == book.AuthorId),
                   AuthorId = book.AuthorId,
                   Format = _context.Formats.First(t => t.Id == book.FormatId),
                   FormatId = book.FormatId,
                   Isbn = book.Isbn,
                   Events = _context.Events.Include(t => t.EventType).Where(t => t.BookId == book.Id).ToList(),
                   MarketMaterials = _context.MarketMaterials.Include(t => t.MarketMaterialType).Where(t => t.BookId == book.Id).ToList(),
                   MarketerAssignments = _context.MarketerAssignments
                   .Where(t => t.BookId == book.Id)
                   .Select(t => new MarketerAssignment
                   {
                       AssignedDt = t.AssignedDt,
                       UnassignedDt = t.UnassignedDt,
                       Marketer = _context.Marketers.First(x => x.Id == t.MarketerId),
                       MarketerId = t.MarketerId,
                       BookId = t.BookId,
                       Id = t.Id
                   })
                   .ToList(),
                   OnSaleDate = book.OnSaleDate,
                   PublishDate = book.PublishDate,
                   Title = book.Title
               };
    }
}
