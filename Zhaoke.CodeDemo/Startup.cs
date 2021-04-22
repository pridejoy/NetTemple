using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoke.CodeDemo
{
    #region  模拟测试类

    public interface ISingTest
    {
        int Age { get; set; }
        string Name { get; set; }
    }

    public class SingTest : ISingTest
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    //--------------------------

    public interface ISconTest
    {
        int Age { get; set; }
        string Name { get; set; }
    }
    public class SconTest : ISconTest
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    //--------------------------
    public interface ITranTest
    {
        int Age { get; set; }
        string Name { get; set; }
    }
    public class TranTest : ITranTest
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    //-----------------------
    public interface IAService
    {
        void RedisTest();
    }

    public class AService : IAService
    {
        private ISingTest sing; ITranTest tran; ISconTest scon;
        public AService(ISingTest sing, ITranTest tran, ISconTest scon)
        {
            this.sing = sing;
            this.tran = tran;
            this.scon = scon;
        }
        public void RedisTest()
        {
            Console.WriteLine("123");
        }
    }

    #endregion

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //注意权重
            services.AddSingleton<ISconTest, SconTest>();
            services.AddTransient<ITranTest, TranTest>();
            services.AddScoped<ISconTest, SconTest>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zhaoke.CodeDemo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,ILoggerFactory loggerFactory )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zhaoke.CodeDemo v1"));
            }

            loggerFactory.AddLog4Net("log4net.Config");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
