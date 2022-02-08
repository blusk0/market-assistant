namespace MarketAssistant.Models.Data;

public class Book
{
    public Book()
    {
        Title = "";
        Isbn = "";
        Author = new Author();
        Format = new Format();
        MarketMaterials = new List<MarketMaterial>();
        MarketerAssignments = new List<MarketerAssignment>();
        Events = new List<Event>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Isbn { get; set; }

    public int FormatId { get; set; }

    public Format Format { get; set; }

    public DateTime OnSaleDate { get; set; }

    public DateTime PublishDate { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public IEnumerable<MarketMaterial> MarketMaterials { get; set; }

    public IEnumerable<MarketerAssignment> MarketerAssignments { get; set; }

    public IEnumerable<Event> Events { get; set; }
}
