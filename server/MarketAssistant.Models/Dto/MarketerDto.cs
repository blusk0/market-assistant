using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto;

public class MarketerDto : IDto<Marketer, MarketerDto>
{
    public MarketerDto()
    {
        FirstName = "";
        LastName = "";
        ImageUrl = "";
        MarketerAssignments = new List<MarketerAssignmentDto>();
    }

    public int Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ImageUrl { get; set; }

    public IEnumerable<MarketerAssignmentDto> MarketerAssignments { get; set; }

    public MarketerDto Adapt(Marketer input)
    {
        return new MarketerDto
        {            
            EmployeeId = input.EmployeeId,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Id = input.Id,
            MarketerAssignments = new MarketerAssignmentDto().AdaptMany(input.Assignments)            
        };
    }

    public MarketerDto Adapt(Marketer input, string hostUrl)
    {
        var marketer = Adapt(input);
        marketer.ImageUrl = $"https://{hostUrl}/images/marketers/{input.Id}.jpeg";
        return marketer;
    }

    public IEnumerable<MarketerDto> AdaptMany(IEnumerable<Marketer> inputs)
    {
        return inputs.Select(Adapt).ToList();
    }

    public IEnumerable<MarketerDto> AdaptMany(IEnumerable<Marketer> inputs, string hostUrl)
    {
        return inputs.Select(x => Adapt(x, hostUrl)).ToList();
    }
}

