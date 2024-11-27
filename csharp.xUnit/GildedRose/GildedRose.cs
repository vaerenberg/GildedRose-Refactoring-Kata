using System.Collections.Generic;

namespace GildedRoseKata;

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
            var type = ItemTypes.Detect(item.Name);

            if (type != ItemType.Legendary)
            {
                item.SellIn--;
                item.Quality = type.Degrade(item.Quality, item.SellIn);
            }
        }
    }

}