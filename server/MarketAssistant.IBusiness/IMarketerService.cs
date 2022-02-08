using MarketAssistant.Models.Dto;

namespace MarketAssistant.IBusiness;

public interface IMarketerService
{
    public Task<MarketerDto> Read(int id, string hostUrl);

    public Task<IEnumerable<MarketerDto>> ReadAll(string hostUrl);

    public Task<IEnumerable<MarketerDto>> ReadNoAssignments(string hostUrl);
}

