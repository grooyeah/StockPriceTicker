using StockPriceTickerServer.Services;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;

namespace StockPriceTickerServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Loopback, 5000);

            listener.Start();

            Console.WriteLine("The server has started...");

            var generator = new StockPriceGenerator();

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("A client has connected...");

                await Task.Run(async () =>
                {
                    using var stream = client.GetStream();

                    while (true)
                    {
                        var stockList = generator.GenerateStockPrices();

                        var stockListJson = JsonSerializer.Serialize(stockList);

                        var buffer = Encoding.UTF8.GetBytes(stockListJson);

                        await stream.WriteAsync(buffer, 0, buffer.Length);

                        await stream.FlushAsync();

                        await Task.Delay(2000);
                    }
                });
            }
        }
    }
}