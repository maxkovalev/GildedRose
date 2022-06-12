
namespace GildedRoseKata.Strategies.Quality
{
    public class QualityStraterySulfuras : IQualityStrategy
    {
        public bool ApplyTo(Item item) => item.Name.StartsWith("Sulfuras");
        
        public int GetQuality(Item item) => item.Quality;
    }
}
