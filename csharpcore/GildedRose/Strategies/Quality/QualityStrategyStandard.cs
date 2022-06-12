
namespace GildedRoseKata.Strategies.Quality
{
    public class QualityStrategyStandard : IQualityStrategy
    {
        public bool ApplyTo(Item item) => false;
        
        public int GetQuality(Item item)
        {
            if (item.Quality == 0) return 0;

            if (item.SellIn <= 0)
                return item.Quality > 1 ?  item.Quality - 2 : 0;
            else
                return item.Quality - 1;
        }
    }
}
