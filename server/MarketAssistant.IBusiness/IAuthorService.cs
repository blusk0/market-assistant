using MarketAssistant.Models.Dto;

namespace MarketAssistant.IBusiness;

public interface IAuthorService
{
    public Task<AuthorDto> Read(int id, string hostUrl);

    public Task<IEnumerable<AuthorDto>> ReadAll(string hostUrl);
}

