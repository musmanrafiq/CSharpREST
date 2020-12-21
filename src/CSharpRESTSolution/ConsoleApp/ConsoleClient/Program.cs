using CSharpREST;
using System;
using System.Threading.Tasks;

namespace ConsoleClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var restClient = new HttpRest();
            var (model, error) = await restClient.GetAsyn<WeatherModel>("http://api.openweathermap.org/data/2.5/weather?q=Pakistan&appid=495cd65a3315d72309042f9e1c3791a");
            Console.WriteLine("Hello World!");
        }
    }
}
