using MarketAssistant.IBusiness;
using MarketAssistant.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MarketAssistant.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarketersController : ControllerBase
{
    private readonly IMarketerService _marketerService;

    public MarketersController(IMarketerService marketerService)
    {
        _marketerService = marketerService;
    }

    [HttpGet]
    public async Task<IEnumerable<MarketerDto>> ReadAll()
    {
        return await _marketerService.ReadAll(Request.Host.Value);
    }

    [HttpGet("{id}")]
    public async Task<MarketerDto> Read(int id)
    {
        return await _marketerService.Read(id, Request.Host.Value);
    }
}

