
namespace GildedRoseKata.Strategies.Quality
{
    public class QualityStrategyBackstagePasses : IQualityStrategy
    {
        public bool ApplyTo(Item item) => item.Name.StartsWith("Backstage passes");
        
        public int GetQuality(Item item)
        {
            if (item.SellIn <= 0) return 0;
            if (item.SellIn <= 5) return item.Quality + 3; 
            if (item.SellIn <= 10) return item.Quality + 2;
            return item.Quality + 1;
        }
    }
}
