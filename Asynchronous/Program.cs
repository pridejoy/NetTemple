using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asynchronous
{

    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var a = GetUrlContentLengthAsync();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(a);
        }
        public static async Task<string> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask =
                client.GetStringAsync("https://www.youtube.com/");

            DoIndependentWork();

            string contents = await getStringTask;

            return contents;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
    }


}
