using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using  log4net;

namespace Net5.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureLogging(loggingBuilder =>
                //{
                //    //����ע�᷽ʽ�����⣬��������ķŷ�ʽ
                //    //loggingBuilder.AddLog4Net("log4net.config");
                //    //һ��Ҫע���ļ���·��
                //    loggingBuilder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
