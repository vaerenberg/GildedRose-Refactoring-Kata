using System;

namespace GildedRoseKata;

public enum ItemType
{
    Normal,
    Legendary,
    Dated,
    Aging,
    Conjured
}

public static class ItemTypes
{
    private static readonly (string key, ItemType type)[] Keywords =
    [
        ("sulfuras", ItemType.Legendary),
        ("concert", ItemType.Dated),
        ("aged", ItemType.Aging),
        ("conjured", ItemType.Conjured)
    ];

    public static ItemType Detect(string name)
    {
        foreach (var (key, type) in Keywords)
        {
            if (name.Contains(key, StringComparison.CurrentCultureIgnoreCase))
            {
                return type;
            }
        }

        return ItemType.Normal;
    }
}

public static class ItemTypeExtensions
{
    public static int Degrade(this ItemType type, int quality, int sellIn)
    {
        var degradation = type switch
        {
            ItemType.Normal => 1,
            ItemType.Legendary => 0,
            ItemType.Dated => sellIn switch
            {
                < 0 => quality,
                < 5 => -3,
                < 10 => -2,
                _ => -1,
            },
            ItemType.Aging => -1,
            ItemType.Conjured => 2,
            _ => throw new ArgumentOutOfRangeException(
                    nameof(type), $"Degradation for ItemType {type} is undefined.")
        };

        if (sellIn < 0)
        {
            degradation *= 2;
        }

        quality -= degradation;
        quality = Math.Max(quality, 0);
        quality = Math.Min(quality, 50);

        return quality;
    }
}