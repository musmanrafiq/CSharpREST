using CSharpREST;
using System;
using System.Threading.Tasks;

namespace ConsoleClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var restClient = new RssFeed();
            var (model, error) = await restClient.GetAsync("https://jaxenter.com/feed");
            Console.WriteLine("Hello World!");
        }
    }
}
