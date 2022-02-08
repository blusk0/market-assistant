namespace MarketAssistant.Models.Data;

public class MarketerAssignment
{
    public MarketerAssignment()
    {
        Book = new Book();
        Marketer = new Marketer();
    }

    public int Id { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }

    public int MarketerId { get; set; }

    public Marketer Marketer { get; set; }

    public DateTime AssignedDt { get; set; }

    public DateTime? UnassignedDt { get; set; }
}

