using System;
using Hangfire;

namespace HangfireDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration
                .UseColouredConsoleLogProvider()
                .UseSqlServerStorage("Server=121.40.104.247;User ID=zk;Password=123456;database=ZhaoShop;");

            //支持基于队列的任务处理：任务执行不是同步的，而是放到一个持久化队列中，以便马上把请求控制权返回给调用者。
            //   BackgroundJob.Enqueue(() => Console.WriteLine("Simple!"));
            //延迟任务执行：不是马上调用方法，而是设定一个未来时间点再来执行。
            //  BackgroundJob.Schedule(() => Console.WriteLine("Reliable!"), TimeSpan.FromSeconds(5));
            //循环任务执行：一行代码添加重复执行的任务，其内置了常见的时间循环模式，也可基于CRON表达式来设定复杂的模式。
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Transparent!"), Cron.Minutely);//注意最小单位是分钟
            
            using (var server = new BackgroundJobServer())
            {
                BackgroundJob.Enqueue(() => Console.WriteLine("Simple111"));

                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
            //RecurringJob.AddOrUpdate(() => Test(), Cron.Minutely);
        }

        //写入作业
       public static void Test()
        {
            //------
            Console.WriteLine("");
        }
    }

  
}
