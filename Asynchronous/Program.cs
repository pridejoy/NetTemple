using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{

    class Program
    {
        static void Main(string[] args)
        {

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //var a = GetVsAsync();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.WriteLine(a);

            //.Net Framework 4.0
            Console.WriteLine("主当前线程唯一标识前：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Test();
            Console.WriteLine("主当前线程唯一标识后：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.Read();
        }


        public async static void Test()
        {
            Console.WriteLine("Test方法-线程唯一标识前：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("开始等待：" + DateTime.Now.ToString());
            await Wait();
            Console.WriteLine("结束等待：" + DateTime.Now.ToString());
            Console.WriteLine("Test方法-线程唯一标识前：" + Thread.CurrentThread.ManagedThreadId.ToString());
            
        }

        public static Task Wait()
        {
            Action action = () =>
            {
                Console.WriteLine("wait方法线程唯一标识前：--》休息两秒" + Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(2000);
                Console.WriteLine("wait方法线程唯一标识后：" + Thread.CurrentThread.ManagedThreadId.ToString());
            };
            Task task = null;
            //    task= TaskEx.Run(action);
            task = new Task(action);
            task.Start();
            return task;
        }
    }


}
