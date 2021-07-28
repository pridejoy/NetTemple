using System;
using System.Collections.Generic;
using System.Linq;

namespace Test1
{
    class Program
    {
        //使用自定义方法读取 
        public static string DataBase { get; set; } = Appsettings.GetConfiguration().GetSection("Audience:Issuer").Value;

        //public static string DataBase { get; set; } = Appsettings.app(new string[] { "Audience", "Issuer" });
        static void Main(string[] args)
        {

            // 测试
            Console.Write(new WeCom().SendToWeCom("爱仕达1231231312313121凄凄切切群凄凄切切群凄凄切切群凄凄切切群凄凄切切群凄凄切切群去去去"));

            //C#如何用统计数组中相同元素个数
            string[] value = new string[] { "DFF11", "DFF11", "RFF11", "RFF11", "RFF11", "CFF11" };
            var source = value.GroupBy(t => t.Trim()).Select(t => new { count = t.Count(), key = t.Key }).ToArray();

            //使用自定义方法读取 
            string iss = Appsettings.GetConfiguration().GetSection("Audience:Issuer").Value; ;
            Console.WriteLine(iss);
        }
    }
}
