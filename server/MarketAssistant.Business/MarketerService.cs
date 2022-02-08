using MarketAssistant.Data;
using MarketAssistant.IBusiness;
using MarketAssistant.Models.Data;
using MarketAssistant.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MarketAssistant.Business;

public class MarketerService : IMarketerService
{
    private readonly MarketContext _context;

    public MarketerService(MarketContext context)
    {
        _context = context;
    }

    public async Task<MarketerDto> Read(int id, string hostUrl)
    {
        return new MarketerDto().Adapt(await ReadAllQuery().Where(t => t.Id == id).FirstAsync(), hostUrl);
    }

    public async Task<IEnumerable<MarketerDto>> ReadAll(string hostUrl)
    {
        return new MarketerDto().AdaptMany(await ReadAllQuery().ToListAsync(), hostUrl);
    }

    public async Task<IEnumerable<MarketerDto>> ReadNoAssignments(string hostUrl)
    {
        return new MarketerDto().AdaptMany(await ReadAllQuery()
            .Where(x => !x.Assignments
            .Any(y => y.UnassignedDt == null)).ToListAsync(), hostUrl);
    }

    private IQueryable<Marketer> ReadAllQuery()
    {
        return from marketer in _context.Marketers.AsNoTracking()
               select new Marketer
               {
                   EmployeeId = marketer.EmployeeId,
                   FirstName = marketer.FirstName,
                   Id = marketer.Id,
                   LastName = marketer.LastName,
                   Assignments = _context.MarketerAssignments
                   .Where(t => t.MarketerId == marketer.Id)
                   .Select(t => new MarketerAssignment
                   {
                       AssignedDt = t.AssignedDt,
                       UnassignedDt = t.UnassignedDt,
                       Book = _context.Books.First(x => x.Id == t.BookId),
                       MarketerId = t.MarketerId,
                       BookId = t.BookId,
                       Id = t.Id
                   })
                   .ToList()
               };
    }
}

