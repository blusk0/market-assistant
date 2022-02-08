namespace MarketAssistant.Models.Data;

public class MarketMaterial
{
    public MarketMaterial()
    {
        Book = new Book();
        MarketMaterialType = new MarketMaterialType();
    }

    public int Id { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }

    public int MarketMaterialTypeId { get; set; }

    public MarketMaterialType MarketMaterialType { get; set; }

    public DateTime StartDt { get; set; }

    public DateTime? EndDt { get; set; }
}

