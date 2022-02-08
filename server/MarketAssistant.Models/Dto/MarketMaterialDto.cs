using MarketAssistant.Models.Data;

namespace MarketAssistant.Models.Dto;

public class MarketMaterialDto : IDto<MarketMaterial, MarketMaterialDto>
{
    public MarketMaterialDto()
    {
        MarketMaterialType = "";
        Book = "";
    }

    public int Id { get; set; }

    public string MarketMaterialType { get; set; }

    public int MarketMaterialTypeId { get; set; }

    public string Book { get; set; }

    public int BookId { get; set; }

    public DateTime StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public MarketMaterialDto Adapt(MarketMaterial input)
    {
        return new MarketMaterialDto
        {
            Id = input.Id,
            Book = input.Book.Title,
            BookId = input.BookId,
            MarketMaterialType = input.MarketMaterialType.Description,
            MarketMaterialTypeId = input.MarketMaterialTypeId,
            StartDt = input.StartDt,
            EndDt = input.EndDt
        };
    }

    public IEnumerable<MarketMaterialDto> AdaptMany(IEnumerable<MarketMaterial> inputs)
    {
        return inputs.Select(Adapt);
    }
}

