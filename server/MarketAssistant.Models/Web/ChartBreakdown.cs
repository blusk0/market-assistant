namespace MarketAssistant.Models.Web;

public class ChartBreakdown
{
    public ChartBreakdown()
    {
        FullyCovered = new ChartTitleItem();
        NoMarketer = new ChartTitleItem();
        NoEvents = new ChartTitleItem();
        NoMaterials = new ChartTitleItem();
        NoCoverage = new ChartTitleItem();
    }

    public ChartTitleItem FullyCovered { get; set; }

    public ChartTitleItem NoMarketer { get; set; }

    public ChartTitleItem NoEvents { get; set; }

    public ChartTitleItem NoMaterials { get; set; }

    public ChartTitleItem NoCoverage { get; set; }
}

