using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void Should_NeverMoreThen50()
        {
            // assign
            var item = new Item() { Name = "Aged Brie", SellIn = 10, Quality = 49 };
            var app = new GildedRose(new List<Item>() { item });

            // act
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            // assert 
            Assert.Equal(50, item.Quality);

        }

        #region Gilded Rose Usecases
        //All items have a SellIn value which denotes the number of days we have to sell the item
        //All items have a Quality value which denotes how valuable the item is
        //At the end of each day our system lowers both values for every item
        //Once the sell by date has passed, Quality degrades twice as fast
        //The Quality of an item is never negative
        //"Aged Brie" actually increases in Quality the older it gets
        //The Quality of an item is never more than 50
        //"Sulfuras, Hand of Ragnaros", being a legendary item, never has to be sold or decreases in Quality
        //"Backstage passes to a TAFKAL80ETC concert", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        #endregion

        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var items = new List<Item>();
            var gR = new GildedRose(items);
            gR.UpdateQuality();
        }

        //At the end of each day our system lowers sellin values for every item
        [Fact]
        public void LowerSellInValueAtEndOfDay_GivenNormalItem()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Normal Item", SellIn = 5, Quality = 30 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(4, items[0].SellIn);
        }

        //At the end of each day our system lowers quality values for every item
        [Fact]
        public void LowerQualityValueAtEndOfDay_GivenNormalItem()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Normal Item", SellIn = 5, Quality = 30 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(29, items[0].Quality);
        }

        //Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void LowerQualityByTwiceValueAtEndOfDay_GivenNormalItemAndSellByDatePassed()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Normal Item", SellIn = 0, Quality = 30 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(28, items[0].Quality);
        }

        //The Quality of an item is never negative
        [Fact]
        public void QualityOfItemCanNotBeNegativeAtEndOfDay_GivenNormalItem()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Normal Item", SellIn = 5, Quality = 1 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();
            gr.UpdateQuality();

            // Assert
            Assert.Equal(3, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        //The Quality of an item is never negative
        [Fact]
        public void QualityOfItemCanNotBeNegativeAtEndOfDay_GivenNormalItemAndSellByDatePassed()
        {
            // Arrange
            var items = new List<Item> { new Item() { Name = "Normal Item", SellIn = 0, Quality = 1 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void QualityOfItemIncreasesAtEndOfDay_GivenItemIsAgedBrie()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 5, Quality = 1 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(2, items[0].Quality);
        }

        //The Quality of an item is never more than 50
        [Fact]
        public void QualityOfItemNeverIncreaseMoreThan50AtEndOfDay_GivenItemIsAgedBrie()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 5, Quality = 50 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(50, items[0].Quality);
        }

        //"Sulfuras, Hand of Ragnaros", being a legendary item, never has to be sold or decreases in Quality
        [Fact]
        public void QualityNeverChangesAtEndOfDay_GivenItemIsSulfuras()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(50, items[0].Quality);
            Assert.Equal(5, items[0].SellIn);
        }

        //"Backstage passes to a TAFKAL80ETC concert", like aged brie, increases in Quality as it's SellIn value approaches; 
        // Quality increases by 2 when there are 10 days or less 
        [Fact]
        public void QualityOfItemIncreasesBy2AtEndOfDay_GivenItemIsBackstagePassesAndSellinIsLessThan10Days()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 1 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(3, items[0].Quality);
        }

        //"Backstage passes to a TAFKAL80ETC concert", like aged brie, increases in Quality as it's SellIn value approaches; 
        // Quality increases by 3 when there are 5 days or less
        [Fact]
        public void QualityOfItemIncreasesBy3AtEndOfDay_GivenItemIsBackstagePassesAndSellinIsLessThan5Days()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(4, items[0].Quality);
        }

        //"Backstage passes to a TAFKAL80ETC concert", like aged brie, increases in Quality as it's SellIn value approaches; 
        // Quality drops to 0 after the concert
        [Fact]
        public void QualityOfItemDropsToZeroAtEndOfDay_GivenItemIsBackstagePassesAndConcertIsOver()
        {
            // Arrage
            var items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 } };

            // Act
            var gr = new GildedRose(items);
            gr.UpdateQuality();

            // Assert
            Assert.Equal(0, items[0].Quality);
        }
    }
}
