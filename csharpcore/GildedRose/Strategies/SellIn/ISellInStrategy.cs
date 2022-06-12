
namespace GildedRoseKata.Strategies.SellIn
{
    public interface ISellInStrategy
    {
        bool ApplyTo(Item item);
        int GetSellIn(Item item);
    }
}
