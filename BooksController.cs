using MarketAssistant.IBusiness;
using MarketAssistant.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MarketAssistant.Web.Controllers;

/// <summary>
/// API Controller for Book related concerns.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Read all Book records.
    /// </summary>
    /// <returns>Collection of BookDto objects.</returns>
    [HttpGet]
    public async Task<IEnumerable<BookDto>> GetAllBooks()
    {
        return await _bookService.ReadAll(Request.Host.Value);
    }

    /// <summary>
    /// Read a single book by Id.
    /// </summary>
    /// <param name="id">The primary key.</param>
    /// <returns>Single BookDto record.</returns>
    [HttpGet("{ids}")]
    public async Task<IEnumerable<BookDto>> GetBookById(string ids)
    {
        return await _bookService.ReadByIds(ids, Request.Host.Value);
    }

    /// <summary>
    /// Read books that do not have any current MarketerAssignments.
    /// </summary>
    /// <returns>Collection of BookDto objects.</returns>
    [HttpGet("no-assignments")]
    public async Task<IEnumerable<BookDto>> GetBooksWithNoAssignments()
    {
        return await _bookService.ReadBooksWithNoAssignments(Request.Host.Value);
    }

    /// <summary>
    /// Read all book records by AuthorId
    /// </summary>
    /// <param name="id">Primary key of the Author.</param>
    /// <returns>Colletion of BookDto objects.</returns>
    [HttpGet("by-author/{id}")]
    public async Task<IEnumerable<BookDto>> GetBooksByAuthor(int id)
    {
        return await _bookService.ReadAllByAuthor(id, Request.Host.Value);        
    }

    /// <summary>
    /// Read MarketerAssignments for provided Book primary key.
    /// </summary>
    /// <param name="id">Primary key of the Book record.</param>
    /// <returns>Collection of MarketerAssignmentDto objects.</returns>
    [HttpGet("{id}/assignments")]
    public async Task<IEnumerable<MarketerAssignmentDto>> GetMarketerAssignments(int id)
    {
        return await _bookService.GetMarketerAssignments(id, Request.Host.Value);
    }
}
