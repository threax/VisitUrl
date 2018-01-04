using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VisitUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("You must include the url to access as the first argument.");
                return;
            }

            Task.Run(async () => await AsyncMain(args)).GetAwaiter().GetResult();
        }

        private static async Task AsyncMain(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = httpClient.GetAsync(args[0]))
                {
                    using (var response = request.Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            Console.Write(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
        }
    }
}
