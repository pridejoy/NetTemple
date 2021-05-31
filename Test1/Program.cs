using System;

namespace Test1
{
    class Program
    {
        //使用自定义方法读取 
        public static string DataBase { get; set; } = Appsettings.GetConfiguration().GetSection("Audience:Issuer").Value;

        //public static string DataBase { get; set; } = Appsettings.app(new string[] { "Audience", "Issuer" });
        static void Main(string[] args)
        {
        //使用自定义方法读取 
         string iss = Appsettings.GetConfiguration().GetSection("Audience:Issuer").Value; ;
            Console.WriteLine(iss);
        }
    }
}
