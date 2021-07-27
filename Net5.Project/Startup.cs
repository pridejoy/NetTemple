using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net5.Common.Helper;
using Net5.Extensions;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Text;
using Hangfire;
using LogDashboard;
using Net5.IServices;
using Net5.Services;
using Hangfire.Dashboard;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.AspNetCore.Http;
using Net5.Project.Base;

namespace Net5.Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // 此方法由运行时调用。使用此方法向容器添加服务。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(r => r.UseSqlServerStorage("Server=121.40.104.247;User ID=zk;Password=123456;database=ZhaoShop;"));
            //不然无法读取配置
            services.AddSingleton(new Appsettings(Configuration));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.Project", Version = "v1" });

                #region 读取xml信息
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Net5.Projecte.xml");//这个就是刚刚配置的xml文件名
                //var xmlModelPath = Path.Combine(basePath, "Net5.Project.Model.xml");//这个就是Model层的xml文件名
                //c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                //c.IncludeXmlComments(xmlModelPath);
                #endregion

                #region Token绑定到ConfigureServices
                // 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                // 添加包管理 Swashbuckle.AspNetCore.Filters
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
            });

            // 1【授权】、这个和上边的异曲同工，好处就是不用在controller中，写多个 roles 
            // 然后这么写 [Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//单独角色
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//或的关系
                options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System"));//且的关系
            });

            //可视化日志
            services.AddLogDashboard();

            #region 参数
            //读取配置文件
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            #endregion

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            //2.1【认证】
            services.AddAuthentication(x =>
                {
                    //看这个单词熟悉么？没错，就是上边错误里的那个。
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })// 也可以直接写字符串，AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,//参数配置在下边
                        ValidateIssuer = true,
                        ValidIssuer = audienceConfig["Issuer"],//发行人
                        ValidateAudience = true,
                        ValidAudience = audienceConfig["Audience"],//订阅人
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                        RequireExpirationTime = true,
                    };

                });


            #region IOC 容器IServiceCollection
            //瞬时生命周期：AddTransient 每一次getService获取的实例都是不同的实例
            //单例生命周期：AddSingleton单例生命周期，在整个进程中获取的都是同一个实例
            //作用域生命周期：AddScoped 同一个作用域，获取的是同一个对象的实例；不同的作用域，获取的是不同的对象实例
            services.AddSingleton<IAdvertisementServices, AdvertisementServices>();


            #endregion
           



            //#region AutoFac

            ////实例化 AutoFac  容器   
            //var builder = new ContainerBuilder();

            ////注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

            ////将services填充到Autofac容器生成器中
            //builder.Populate(services);

            ////使用已进行的组件登记创建新容器
            //var ApplicationContainer = builder.Build();

            //#endregion
        }

        // 此方法由运行时调用。使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5.Project v1"));

            }

            //启用可视化日志
            app.UseLogDashboard();

            //启用log4
            loggerFactory.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));

            app.UseHttpsRedirection();

            app.UseRouting();

            #region Hangfire定时任务
            var queues = new string[] { "default", "apis", "web", "recurring" };
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ServerTimeout = TimeSpan.FromMinutes(4),
                SchedulePollingInterval = TimeSpan.FromSeconds(15),//秒级任务需要配置短点，一般任务可以配置默认时间，默认15秒
                ShutdownTimeout = TimeSpan.FromMinutes(30),//超时时间
                Queues = queues,//队列
                WorkerCount = Math.Max(Environment.ProcessorCount, 20)//工作线程数，当前允许的最大线程，默认20
            });

            //授权
            var filter = new BasicAuthAuthorizationFilter(
                new BasicAuthAuthorizationFilterOptions
                {
                    SslRedirect = false,
                    // Require secure connection for dashboard
                    RequireSsl = false,
                    // Case sensitive login checking
                    LoginCaseSensitive = false,
                    // Users
                    Users = new[]
                    {
                        new BasicAuthAuthorizationUser
                        {
                            Login = "admin",//访问账号
                            PasswordClear ="123456" //访问密码
                        }
                    }
                });
            var options = new DashboardOptions
            {
                AppPath = "/",//返回时跳转的地址
                DisplayStorageConnectionString = false,//是否显示数据库连接信息
                Authorization = new[]
                {
                    filter
                },
                IsReadOnlyFunc = Context =>
                {
                    return false;//是否只读面板
                }
            };

            app.UseHangfireDashboard("/job", options); //可以改变Dashboard的url
            HangfireDispose.HangfireService();

            #endregion

            app.UseHangfireServer();
            app.UseHangfireDashboard();


            app.Map("/index", r =>
            {
                r.Run(context =>
                {
                    //任务每分钟执行一次
                    RecurringJob.AddOrUpdate(() => Console.WriteLine($"ASP.NET Core LineZero"), Cron.Minutely());
                    return context.Response.WriteAsync("ok");
                });
            });

            // 先开启认证
            app.UseAuthentication();

            // 然后是授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterModule(new AutofacModuleRegister());
        //}

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }

    }
}
