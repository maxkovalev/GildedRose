
namespace GildedRoseKata.Strategies.Quality
{
    public class QualityStrategyConjured : IQualityStrategy
    {
        public bool ApplyTo(Item item) => item.Name.StartsWith("Conjured");
        
        public int GetQuality(Item item)
        {
            if (item.Quality < 2) return 0;
            return item.Quality -2;
       }
    }
}
