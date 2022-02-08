namespace MarketAssistant.Models.Data;

public class Marketer
{
    public Marketer()
    {
        FirstName = "";
        LastName = "";        
        Assignments = new List<MarketerAssignment>();
    }

    public int Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IEnumerable<MarketerAssignment> Assignments { get; set; }
}