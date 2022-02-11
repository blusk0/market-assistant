using MarketAssistant.Models.Dto;
using MarketAssistant.Models.Web;

namespace MarketAssistant.IBusiness;
public interface IBookService
{
    public Task<IEnumerable<BookDto>> ReadByIds(string ids, string hostUrl);

    public Task<IEnumerable<BookDto>> ReadAll(string hostUrl);

    public Task<IEnumerable<BookDto>> ReadAllWithinRange(string hostUrl, DateTime? startDate = null, DateTime? endDate = null);

    public Task<IEnumerable<BookDto>> ReadAllByAuthor(int authorId, string hostUrl);

    public Task<IEnumerable<MarketerAssignmentDto>> GetMarketerAssignments(int bookId, string hostUrl);

    public Task<IEnumerable<BookDto>> ReadBooksWithNoAssignments(string hostUrl);

    public Task<ChartBreakdown> ReadBookChartBreakdown();
}
