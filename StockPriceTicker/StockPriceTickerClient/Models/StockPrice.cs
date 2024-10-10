namespace StockPriceTickerClient.Models
{
    public class StockPrice
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ChangePercentage { get; set; }
        public DateTime LastUpdated { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Price:C} ({ChangePercentage:+0.00;-0.00}%) Last Updated: {LastUpdated}";
        }
    }
}
