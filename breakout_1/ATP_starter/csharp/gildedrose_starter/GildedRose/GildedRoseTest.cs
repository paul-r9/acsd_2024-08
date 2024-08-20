using System.Collections.Generic;
using NUnit.Framework;


namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void item_name_does_not_change()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose sut = new GildedRose(items);
            
            // Act
            sut.UpdateQuality();
            
            // Assert
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void quality_could_not_go_negative()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.IsTrue(items[0].Quality >= 0,"Quality should never be negative.");
        }

        [Test]
        public void quality_degrades_twice_as_fast_when_sell_by_date_has_passed()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void quality_of_an_item_is_never_negative()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.IsTrue(items[0].Quality >= 0, "Quality should never be negative.");
        }

        [Test]
        public void aged_brie_increases_in_quality_the_older_it_gets()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void aged_brie_increases_in_quality_past_sellin_date()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void aged_brie_is_never_more_than_50()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.IsTrue(items[0].Quality <= 50, "Quality should never be more than 50.");
        }

        [Test]
        public void aged_brie_above_50_stays_above_50()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 51 } };
            GildedRose sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            //Assert.IsTrue(items[0].Quality <= 50, "Quality should never be more than 50.");
            Assert.IsFalse(items[0].Quality <= 50, "Quality is above 50");
        }
    }
}
