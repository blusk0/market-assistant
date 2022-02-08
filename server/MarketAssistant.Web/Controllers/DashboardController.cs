using MarketAssistant.IBusiness;
using MarketAssistant.Models.Dto;
using MarketAssistant.Models.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketAssistant.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IMarketerService _marketersService;
    private readonly IBookService _bookService;

    public DashboardController(IMarketerService marketersService, IBookService bookService)
    {
        _marketersService = marketersService;
        _bookService = bookService;
    }

    [HttpGet("chart")]
    public async Task<ChartBreakdown> GetChartBreakdown()
    {
        return await _bookService.ReadBookChartBreakdown();
    }

    [HttpGet("marketers-without-assignments")]
    public async Task<IEnumerable<MarketerDto>> GetMarketersWithoutAssignments()
    {
        return await _marketersService.ReadNoAssignments(Request.Host.Value);
    }

    [HttpGet("upcoming-books")]
    public async Task<IEnumerable<BookDto>> GetNearlyPublishedBooks()
    {
        return await _bookService.ReadAllWithinRange(Request.Host.Value, endDate: DateTime.UtcNow.AddDays(30));
    }
}

