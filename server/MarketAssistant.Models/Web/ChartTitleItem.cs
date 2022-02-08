namespace MarketAssistant.Models.Web;

public class ChartTitleItem
{
    public ChartTitleItem()
    {
        Name = "";
        TitleIds = new List<int>();
    }

    public string Name { get; set; }

    public List<int> TitleIds { get; set; }

    public int Value => TitleIds.Count;
}
