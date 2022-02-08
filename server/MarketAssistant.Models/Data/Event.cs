namespace MarketAssistant.Models.Data;

public class Event
{
    public Event()
    {
        EventType = new EventType();
        Book = new Book();
    }

    public int Id { get; set; }

    public DateTime EventDt { get; set; }

    public int EventTypeId { get; set; }

    public EventType EventType { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }
}
