using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MbtaPredictor
{
    public class WebCalls
    {
        public static async Task<string> GetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    return result;
                }
            }
        }
    }
}
