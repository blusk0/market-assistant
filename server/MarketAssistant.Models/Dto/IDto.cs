namespace MarketAssistant.Models.Dto;

public interface IDto<Tin, Tout>
{
    public Tout Adapt(Tin input);

    public IEnumerable<Tout> AdaptMany(IEnumerable<Tin> inputs);
}
