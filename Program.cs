using System.Net.Http.Json;

namespace WebConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string url = "https://en.wikipedia.org/w/api.php?action=query&titles=Cristiano%20Ronaldo&prop=revisions&rvprop=content&format=json";
            const string weatherForecastUrl = "http://localhost:5062/api/WeatherForecast";

            HttpClient client = new HttpClient();

            var response = await client.GetFromJsonAsync<WeatherForecast[]>(weatherForecastUrl);

            Console.WriteLine("Wikipedia API Response:");
            foreach (WeatherForecast r in response)
            { 
                Console.WriteLine($"{r.Date} - {r.Summary}");
            }
        }
    }
}
