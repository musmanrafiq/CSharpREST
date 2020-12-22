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
            var (model, error) = await restClient.GetaAsync("http://feeds.feedburner.com/dave-brock");
            Console.WriteLine("Hello World!");
        }
    }
}
