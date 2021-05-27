using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    public class 异步
    {
        public static void DoSmaple()
        {

            callasync();
            Console.ReadLine();

        }

        static Task<string> GetAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                Thread.Sleep(2000);
                return string.Format($"你好！{name}");

            });
        }

        async static void callasync()
        {

            //需要加上await关键字
            var result = await GetAsync("李焕英");
            Console.WriteLine(result);


        }
    }
}
