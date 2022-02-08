using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto;

public class MarketerAssignmentDto : IDto<MarketerAssignment, MarketerAssignmentDto>
{
    public MarketerAssignmentDto()
    {
        Marketer = new MarketerDto();
        Book = new BookDto();
    }

    public int Id { get; set; }

    public MarketerDto Marketer { get; set; }

    public BookDto Book { get; set; }

    public DateTime AssignedDt { get; set; }

    public DateTime? UnassignedDt { get; set; }

    public MarketerAssignmentDto Adapt(MarketerAssignment assignment)
    {
        return new MarketerAssignmentDto
        {
            Id = assignment.Id,
            Marketer = new MarketerDto().Adapt(assignment.Marketer),
            Book = new BookDto().Adapt(assignment.Book),
            AssignedDt = assignment.AssignedDt,
            UnassignedDt = assignment.UnassignedDt
        };
    }

    public MarketerAssignmentDto Adapt(MarketerAssignment assignment, string hostUrl)
    {
        return new MarketerAssignmentDto
        {
            Id = assignment.Id,
            Marketer = new MarketerDto().Adapt(assignment.Marketer, hostUrl),
            Book = new BookDto().Adapt(assignment.Book, hostUrl),
            AssignedDt = assignment.AssignedDt,
            UnassignedDt = assignment.UnassignedDt
        };
    }

    public IEnumerable<MarketerAssignmentDto> AdaptMany(IEnumerable<MarketerAssignment> assignments)
    {
        return assignments.Select(Adapt).ToList();
    }

    public IEnumerable<MarketerAssignmentDto> AdaptMany(IEnumerable<MarketerAssignment> assignments, string hostUrl)
    {
        return assignments.Select(x => Adapt(x, hostUrl)).ToList();
    }
}
