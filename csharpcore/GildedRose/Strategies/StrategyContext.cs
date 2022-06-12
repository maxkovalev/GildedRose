using GildedRoseKata.Strategies.Quality;
using GildedRoseKata.Strategies.SellIn;

namespace GildedRoseKata.Strategies
{
    /// <summary>
    /// Strategy context to update quality and sellIn values
    /// </summary>
    public class StrategyContext
    {
        private readonly IQualityStrategy qualityStrategy;
        private readonly ISellInStrategy sellInStrategy;
        private readonly Item item;

        public StrategyContext(
            IQualityStrategy qualityStrategy,
            ISellInStrategy sellInStrategy,
            Item item)
        {
            this.item = item;
            this.qualityStrategy = qualityStrategy;
            this.sellInStrategy = sellInStrategy;
        }

        public int GetQuality() => this.qualityStrategy.GetQuality(this.item);

        public int GetSellIn() => this.sellInStrategy.GetSellIn(this.item);

    }
}
