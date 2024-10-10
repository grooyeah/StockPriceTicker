using System;

namespace StockPriceTickerServer.Models
{
    public class StockPrice
    {
        private decimal _price;
        public string Name { get; private set; }
        public decimal Price
        {
            get => _price;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price for stock cannot be negative.");
                }

                _price = value;
            }
        }
        public decimal ChangePercentage { get; private set; }
        public DateTime LastUpdated { get; private set; }


        public StockPrice(string name, decimal initialPrice)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name for stock cannot be null or empty.");
            }

            Name = name;
            Price = initialPrice;
            ChangePercentage = 0;
            LastUpdated = DateTime.Now;
        }

        public void UpdatePrice(decimal newPrice)
        {
            ChangePercentage = ((newPrice - Price) / Price) * 100;
            Price = newPrice;
            LastUpdated = DateTime.Now;
        }
    }
}
