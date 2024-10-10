using StockPriceTickerServer.Models;
using Xunit;

namespace StockPriceTickerTests
{
    public class StockPriceModelTests
    {
        [Fact]
        public void StockPriceModel_CreatesValidStock()
        {
            // Arrange & Act
            var stock = new StockPrice("Apple", 1500.50m);

            // Assert
            Assert.Equal("Apple", stock.Name);
            Assert.Equal(1500.50m, stock.Price);
        }

        [Fact]
        public void StockPriceModel_ThrowsOnInvalidPrice()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new StockPrice("Apple", -1000));
        }

        [Fact]
        public void StockPriceModel_ThrowsOnInvalidName()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new StockPrice("", 1000));
        }

        [Fact]
        public void StockPriceModel_UpdatesPriceCorrectly()
        {
            // Arrange
            var stock = new StockPrice("Google", 100m);

            // Act
            stock.UpdatePrice(150m);

            // Assert
            Assert.Equal(150m, stock.Price);
            Assert.InRange(stock.ChangePercentage, 50m, 50.1m);
        }
    }
}