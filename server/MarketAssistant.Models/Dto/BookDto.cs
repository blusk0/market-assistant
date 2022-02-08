using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto;

public class BookDto : IDto<Book, BookDto>
{
    public BookDto()
    {
        Title = "";
        Isbn = "";
        AuthorFirstName = "";
        AuthorLastName = "";
        Format = "";
        MarketMaterials = new List<MarketMaterialDto>();
        MarketerAssignments = new List<MarketerAssignmentDto>();
        Events = new List<EventDto>();
        ImageUrl = "";
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Isbn { get; set; }

    public int AuthorId { get; set; }

    public string AuthorFirstName { get; set; }

    public string AuthorLastName { get; set; }

    public string Format { get; set; }

    public string ImageUrl { get; set; }

    public DateTime OnSaleDate { get; set; }

    public DateTime PublishDate { get; set; }

    public IEnumerable<MarketMaterialDto> MarketMaterials { get; set; }

    public IEnumerable<MarketerAssignmentDto> MarketerAssignments { get; set; }

    public IEnumerable<EventDto> Events { get; set; }

    public BookDto Adapt(Book input)
    {
        return new BookDto
        {
            AuthorFirstName = input.Author.FirstName,
            AuthorLastName = input.Author.LastName,
            AuthorId = input.Author.Id,
            Id = input.Id,
            Isbn = input.Isbn,
            Title = input.Title,
            Format = input.Format.Description,
            OnSaleDate = input.OnSaleDate,
            PublishDate = input.PublishDate,
            MarketMaterials = new MarketMaterialDto().AdaptMany(input.MarketMaterials),
            MarketerAssignments = new MarketerAssignmentDto().AdaptMany(input.MarketerAssignments),
            Events = new EventDto().AdaptMany(input.Events),            
        };
    }

    public BookDto Adapt(Book input, string hostUrl)
    {
        var book = Adapt(input);
        book.ImageUrl = $"https://{hostUrl}/images/books/{input.Id}.jpg";
        return book;
    }

    public IEnumerable<BookDto> AdaptMany(IEnumerable<Book> inputs)
    {
        return inputs.Select(Adapt).ToList();
    }

    public IEnumerable<BookDto> AdaptMany(IEnumerable<Book> inputs, string hostUrl)
    {
        return inputs.Select(x => Adapt(x, hostUrl)).ToList();
    }
}
