using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using StockPriceTickerClient.Models;

namespace StockPriceTickerClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new TcpClient();

            await client.ConnectAsync("127.0.0.1", 5000);

            Console.WriteLine("Connected to the server...");

            var buffer = new byte[1024 * 10];

            var stream = client.GetStream();

            while (true)
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                var stockJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                try
                {
                    var stockList = JsonSerializer.Deserialize<List<StockPrice>>(stockJson);

                    foreach (var stock in stockList)
                    {
                        Console.WriteLine(stock.ToString());
                    }

                    Console.WriteLine("\n");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Exception thrown while parsing stock data : {ex.Message}");
                }
            }
        }
    }
}