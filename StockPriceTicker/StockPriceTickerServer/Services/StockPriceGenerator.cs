using StockPriceTickerServer.Models;

namespace StockPriceTickerServer.Services
{
    public class StockPriceGenerator
    {
        private readonly string[] _stockNames = { "Apple", "Google", "Microsoft", "Amazon", "Berkshire" };
        private readonly Random _random = new Random();
        private readonly List<StockPrice> _stocks;

        public StockPriceGenerator()
        {
            _stocks = new List<StockPrice>();
            
            foreach (var stockName in _stockNames)
            {
                _stocks.Add(new StockPrice(stockName, GenerateRandomStockPrice()));
            }
        }

        public IEnumerable<StockPrice> GenerateStockPrices()
        {
            foreach (var stock in _stocks)
            {
                var newPrice = GenerateRandomStockPrice();

                stock.UpdatePrice(newPrice);
            }

            return _stocks;
        }

        private decimal GenerateRandomStockPrice()
        {
            return (decimal)(_random.NextDouble() * 1000);
        }
    }
}
