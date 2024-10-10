using StockPriceTickerServer.Services;
using Xunit;

namespace StockPriceTickerTests
{
    public class StockPriceGeneratorTests
    {
        [Fact]
        public void StockPriceGenerator_CreatesStocks()
        {
            // Arrange
            var generator = new StockPriceGenerator();

            // Act
            var stocks = generator.GenerateStockPrices();

            // Assert
            Assert.NotNull(stocks);
            Assert.NotEmpty(stocks);
        }

        [Fact]
        public void StockPriceGenerator_UpdatesStockPrices()
        {
            // Arrange
            var generator = new StockPriceGenerator();

            var initialStocks = generator.GenerateStockPrices();

            var initialPrices = new List<decimal>();

            foreach (var stock in initialStocks)
            {
                initialPrices.Add(stock.Price);
            }

            // Act
            var updatedStocks = generator.GenerateStockPrices();

            // Assert
            int index = 0;

            foreach (var stock in updatedStocks)
            {
                Assert.NotEqual(initialPrices[index], stock.Price);

                index++;
            }
        }
    }
}
