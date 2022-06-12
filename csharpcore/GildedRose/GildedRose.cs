using GildedRoseKata.Factories;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var context = StrategyContextFactory.GetStrategyContext(item);
                item.Quality = context.GetQuality();
                item.SellIn = context.GetSellIn();
            }
        }
    }
}
