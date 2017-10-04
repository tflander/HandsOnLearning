using System;
using System.Collections.Generic;

namespace Katas
{
    public class GildedRose
    {
        private static IList<Item> items = null;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            items = new List<Item>
            {
                new Item("+5 Dexterity Vest", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Sulfuras, Hand of Ragnaros", 0, 80),
                new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new Item("Conjured Mana Cake", 3, 6)
            };

            UpdateQuality();
        }

		private static void UpdateQuality()
		{
			for (int i = 0; i < items.Count; i++)
			{
				if ((!"Aged Brie".Equals(items[i].Name)) && !"Backstage passes to a TAFKAL80ETC concert".Equals(items[i].Name))
				{
					if (items[i].Quality > 0)
					{
						if (!"Sulfuras, Hand of Ragnaros".Equals(items[i].Name))
						{
							items[i].Quality = items[i].Quality - 1;
						}
					}
				}
				else
				{
					if (items[i].Quality < 50)
					{
						items[i].Quality = items[i].Quality + 1;

						if ("Backstage passes to a TAFKAL80ETC concert".Equals(items[i].Name))
						{
							if (items[i].SellIn < 11)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = (items[i].Quality + 1);
								}
							}

							if (items[i].SellIn < 6)
							{
								if (items[i].Quality < 50)
								{
									items[i].Quality = (items[i].Quality + 1);
								}
							}
						}
					}
				}

				if (!"Sulfuras, Hand of Ragnaros".Equals(items[i].Name))
				{
					items[i].SellIn = (items[i].SellIn - 1);
				}

				if (items[i].SellIn < 0)
				{
					if (!"Aged Brie".Equals(items[i].Name))
					{
						if (!"Backstage passes to a TAFKAL80ETC concert".Equals(items[i].Name))
						{
							if (items[i].Quality > 0)
							{
								if (!"Sulfuras, Hand of Ragnaros".Equals(items[i].Name))
								{
									items[i].Quality = (items[i].Quality - 1);
								}
							}
						}
						else
						{
							items[i].Quality = (items[i].Quality - items[i].Quality);
						}
					}
					else
					{
						if (items[i].Quality < 50)
						{
							items[i].Quality = (items[i].Quality + 1);
						}
					}
				}
			}
		}
    }
}
