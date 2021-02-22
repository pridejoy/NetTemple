using System;
using System.Threading;
using System.Threading.Tasks;

namespace 异步
{
    class Program
    {
        static void Main(string[] args)
        {
            callasync();
            Console.ReadLine();
        }


        static Task<string> GetAsync(string name) {
            return Task.Run<string>(()=>
            {
                Thread.Sleep(2000);
                return string.Format($"你好！{name}");

            });
        }

        async static void callasync() {

            //需要加上await关键字
            var result = await GetAsync("李焕英");
            Console.WriteLine(result);


        }
    }
}
