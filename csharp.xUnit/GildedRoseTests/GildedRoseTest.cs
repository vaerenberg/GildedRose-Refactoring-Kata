using Xunit;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void ConjuredItems_DegradeFaster(int days)
    {
        // Arrange
        var initialQuality = 30;
        var normal = new Item { Name = "Normal item", SellIn = 10, Quality = initialQuality };
        var conjured = new Item { Name = "Conjured item", SellIn = 10, Quality = initialQuality };
        var app = new GildedRose([normal, conjured]);

        // Act
        for (int i = 0; i < days; i++)
        {
            app.UpdateQuality();
        }

        // Assert
        Assert.Equal(initialQuality - days, normal.Quality);
        Assert.Equal(initialQuality - 2 * days, conjured.Quality);
    }
}