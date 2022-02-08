using MarketAssistant.Data;
using MarketAssistant.IBusiness;
using MarketAssistant.Models.Data;
using MarketAssistant.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MarketAssistant.Business;

public class AuthorService : IAuthorService
{
    private readonly MarketContext _context;

    public AuthorService(MarketContext context)
    {
        _context = context;
    }

    public async Task<AuthorDto> Read(int id, string hostUrl)
    {
        return new AuthorDto().Adapt(await ReadAllQuery().FirstAsync(x => x.Id == id), hostUrl);
    }

    public async Task<IEnumerable<AuthorDto>> ReadAll(string hostUrl)
    {
        return new AuthorDto().AdaptMany(await ReadAllQuery().ToListAsync(), hostUrl);
    }

    private IQueryable<Author> ReadAllQuery()
    {
        return from author in _context.Authors.AsNoTracking()
               select new Author
               {
                   Id = author.Id,
                   FirstName = author.FirstName,
                   LastName = author.LastName,
                   Books = _context.Books.Include(t => t.Format).AsNoTracking().Where(t => t.AuthorId == author.Id).ToList()
               };
    }
}

