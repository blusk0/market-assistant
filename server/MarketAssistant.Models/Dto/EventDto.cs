using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto;

public class EventDto : IDto<Event, EventDto>
{
    public EventDto()
    {
        EventType = "";
        Book = new BookDto();
    }

    public int Id { get; set; }

    public string EventType { get; set; }

    public BookDto Book { get; set; }

    public DateTime EventDt { get; set; }

    public EventDto Adapt(Event input)
    {
        return new EventDto
        {
            Book = new BookDto().Adapt(input.Book),
            EventType = input.EventType.Description,
            Id = input.Id,
            EventDt = input.EventDt
        };
    }

    public IEnumerable<EventDto> AdaptMany(IEnumerable<Event> inputs)
    {
        return inputs.Select(Adapt).ToList();
    }
}
