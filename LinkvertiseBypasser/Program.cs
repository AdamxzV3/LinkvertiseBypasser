using System;
using System.Net.Http;
using System.Text.Json;

namespace LinkvertiseBypasser
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Enter the Linkvertise URL:");
            string linkvertiseUrl = Console.ReadLine();

            using var client = new HttpClient();
            var response = await client.GetAsync($"https://bypass.bot.nu/bypass2?url={linkvertiseUrl}");
            var responseString = await response.Content.ReadAsStringAsync();
            var bypassedUrl = JsonSerializer.Deserialize<BypassedUrl>(responseString);

            Console.WriteLine($"Destination: {bypassedUrl.destination}");
            Console.WriteLine($"Success: {bypassedUrl.success}");
        }
    }

    class BypassedUrl
    {
        public string destination { get; set; }
        public bool success { get; set; }
    }
}
