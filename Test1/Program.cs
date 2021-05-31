using System;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            string iss = Appsettings.app(new string[] { "Audience", "Issuer" });
            Console.WriteLine(iss);
        }
    }
}
