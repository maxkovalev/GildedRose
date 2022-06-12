
namespace GildedRoseKata.Strategies.SellIn
{
    public class SellInStrategySulfuras : ISellInStrategy
    {
        public bool ApplyTo(Item item) => item.Name.StartsWith("Sulfuras");
        
        public int GetSellIn(Item item) => item.SellIn;
    }
}
