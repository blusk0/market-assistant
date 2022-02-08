using MarketAssistant.IBusiness;
using MarketAssistant.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MarketAssistant.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorsService;

    public AuthorsController(IAuthorService authorsService)
    {
        _authorsService = authorsService;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorDto>> ReadAll()
    {
        return await _authorsService.ReadAll(Request.Host.Value);
    }

    [HttpGet("{id}")]
    public async Task<AuthorDto> Read(int id)
    {
        return await _authorsService.Read(id, Request.Host.Value);
    }
}

