using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private const int MAX_QUALITY_AMOUNT = 50;
        private const int MIN_QUALITY_AMOUNT = 0;
        private const string AGED_BRIE_NAME = "Aged Brie";
        private const string BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        private readonly IList<Item> _items;
        public IList<Item> Items => _items;

        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (!item.Name.Equals(AGED_BRIE_NAME) && !item.Name.Equals(BACKSTAGE_PASS_NAME))
                {
                    if (item.Quality > MIN_QUALITY_AMOUNT)
                    {
                        if (!item.Name.Equals(SULFURAS_NAME))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MAX_QUALITY_AMOUNT)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name.Equals(BACKSTAGE_PASS_NAME))
                        {
                            // When the SellIn date pass 10 days
                            if (item.SellIn <= 10)
                            {
                                IncreaseQuality(item);
                            }

                            // When the SellIn date pass 5 days
                            if (item.SellIn <= 5)
                            {
                                IncreaseQuality(item);
                            }
                        }
                    }
                }

                if (!item.Name.Equals(SULFURAS_NAME))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!item.Name.Equals(AGED_BRIE_NAME))
                    {
                        if (!item.Name.Equals(BACKSTAGE_PASS_NAME))
                        {
                            if (item.Quality > MIN_QUALITY_AMOUNT)
                            {
                                if (!item.Name.Equals(SULFURAS_NAME))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        IncreaseQuality(item);
                    }
                }
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MAX_QUALITY_AMOUNT)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}