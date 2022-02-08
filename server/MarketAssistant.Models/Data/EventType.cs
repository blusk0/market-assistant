namespace MarketAssistant.Models.Data;

public class EventType
{
    public EventType()
    {
        Description = "";
    }

    public int Id { get; set; }

    public string Description { get; set; }
}
