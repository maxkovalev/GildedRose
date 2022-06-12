using System.Linq;
using GildedRoseKata.Strategies;
using GildedRoseKata.Strategies.Quality;
using GildedRoseKata.Strategies.SellIn;

namespace GildedRoseKata.Factories
{
    public class StrategyContextFactory
    {
        private static readonly IQualityStrategy[] qualityStrategies;
        private static readonly ISellInStrategy[] sellInStrategies;

        static StrategyContextFactory()
        {
            qualityStrategies = new IQualityStrategy[]
            {
                new QualityStrategyBackstagePasses(),
                new QualityStrategyConjured(),
                new QualityStrategyStandard(),
                new QualityStrategyAgedBrie(),
                new QualityStraterySulfuras()
            };

            sellInStrategies = new ISellInStrategy[]
            {
                new SellInStrategySulfuras(),
                new SellInStrategyStandard()
            };
        }

        public static StrategyContext GetStrategyContext(Item item)
        {
            var qualityStrategy =
                qualityStrategies.FirstOrDefault(s => s.ApplyTo(item))
                ?? qualityStrategies.FirstOrDefault(s => s.GetType().Equals(typeof(QualityStrategyStandard)));

            var sellStrategy =
                sellInStrategies.FirstOrDefault(s => s.ApplyTo(item))
                ?? sellInStrategies.FirstOrDefault(s => s.GetType().Equals(typeof(SellInStrategyStandard)));

            return new StrategyContext(qualityStrategy, sellStrategy, item);
        }
    }
}
