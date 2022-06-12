
namespace GildedRoseKata.Strategies.SellIn
{
    public class SellInStrategyStandard : ISellInStrategy
    {
        public bool ApplyTo(Item item) => false;
        
        public int GetSellIn(Item item) => item.SellIn - 1; 
    }
}
