using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MbtaPredictor
{
    public class WebCalls
    {
        public static async Task<string> GetUrl(string url)
        {
            Console.WriteLine("Task created");
            using (var client = new HttpClient())
            {
                Console.WriteLine("Declared new HttpClient");
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    Console.WriteLine("Awaiting Result");
                    string result = await r.Content.ReadAsStringAsync();
                    Console.WriteLine("Got Result");
                    Console.WriteLine(result);
                    Console.WriteLine("Result on line above");
                    return result;
                }
            }
        }
    }
}
