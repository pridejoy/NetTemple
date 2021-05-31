using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
                //改用Autofac来实现依赖注入
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                //.ConfigureLogging(loggingBuilder =>
                //{
                //    //一定要注意文件的路径
                //    loggingBuilder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
