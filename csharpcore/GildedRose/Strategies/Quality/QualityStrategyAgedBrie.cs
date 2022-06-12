
namespace GildedRoseKata.Strategies.Quality
{
    public class QualityStrategyAgedBrie : IQualityStrategy
    {
        public bool ApplyTo(Item item) => item.Name.StartsWith("Aged Brie");
        
        public int GetQuality(Item item)
        {
            if (item.Quality == 50) return 50;
            return item.Quality +1;
        }
    }
}
