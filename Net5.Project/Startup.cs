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



        // �˷���������ʱ���á�ʹ�ô˷�����������ӷ���
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(r => r.UseSqlServerStorage("Server=121.40.104.247;User ID=zk;Password=123456;database=ZhaoShop;"));
            //��Ȼ�޷���ȡ����
            services.AddSingleton(new Appsettings(Configuration));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Net5.Project", Version = "v1" });

                #region ��ȡxml��Ϣ
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Net5.Projecte.xml");//������Ǹո����õ�xml�ļ���
                //var xmlModelPath = Path.Combine(basePath, "Net5.Project.Model.xml");//�������Model���xml�ļ���
                //c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�
                //c.IncludeXmlComments(xmlModelPath);
                #endregion

                #region Token�󶨵�ConfigureServices
                // ������ȨС��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // ��header�����token�����ݵ���̨
                // ��Ӱ����� Swashbuckle.AspNetCore.Filters
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
            });

            // 1����Ȩ����������ϱߵ�����ͬ�����ô����ǲ�����controller�У�д��� roles 
            // Ȼ����ôд [Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//������ɫ
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//��Ĺ�ϵ
                options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System"));//�ҵĹ�ϵ
            });

            //���ӻ���־
            services.AddLogDashboard();

            #region ����
            //��ȡ�����ļ�
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            #endregion

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            //2.1����֤��
            services.AddAuthentication(x =>
                {
                    //�����������Ϥô��û�������ϱߴ�������Ǹ���
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })// Ҳ����ֱ��д�ַ�����AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,//�����������±�
                        ValidateIssuer = true,
                        ValidIssuer = audienceConfig["Issuer"],//������
                        ValidateAudience = true,
                        ValidAudience = audienceConfig["Audience"],//������
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,//����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹���ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ��+���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
                        RequireExpirationTime = true,
                    };

                });


            #region IOC ����IServiceCollection
            //˲ʱ�������ڣ�AddTransient ÿһ��getService��ȡ��ʵ�����ǲ�ͬ��ʵ��
            //�����������ڣ�AddSingleton�����������ڣ������������л�ȡ�Ķ���ͬһ��ʵ��
            //�������������ڣ�AddScoped ͬһ�������򣬻�ȡ����ͬһ�������ʵ������ͬ�������򣬻�ȡ���ǲ�ͬ�Ķ���ʵ��
            services.AddSingleton<IAdvertisementServices, AdvertisementServices>();


            #endregion
           



            //#region AutoFac

            ////ʵ���� AutoFac  ����   
            //var builder = new ContainerBuilder();

            ////ע��Ҫͨ�����䴴�������
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

            ////��services��䵽Autofac������������
            //builder.Populate(services);

            ////ʹ���ѽ��е�����ǼǴ���������
            //var ApplicationContainer = builder.Build();

            //#endregion
        }

        // �˷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5.Project v1"));

            }

            //���ÿ��ӻ���־
            app.UseLogDashboard();

            //����log4
            loggerFactory.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));

            app.UseHttpsRedirection();

            app.UseRouting();

            #region Hangfire��ʱ����
            var queues = new string[] { "default", "apis", "web", "recurring" };
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ServerTimeout = TimeSpan.FromMinutes(4),
                SchedulePollingInterval = TimeSpan.FromSeconds(15),//�뼶������Ҫ���ö̵㣬һ�������������Ĭ��ʱ�䣬Ĭ��15��
                ShutdownTimeout = TimeSpan.FromMinutes(30),//��ʱʱ��
                Queues = queues,//����
                WorkerCount = Math.Max(Environment.ProcessorCount, 20)//�����߳�������ǰ���������̣߳�Ĭ��20
            });

            //��Ȩ
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
                            Login = "admin",//�����˺�
                            PasswordClear ="123456" //��������
                        }
                    }
                });
            var options = new DashboardOptions
            {
                AppPath = "/",//����ʱ��ת�ĵ�ַ
                DisplayStorageConnectionString = false,//�Ƿ���ʾ���ݿ�������Ϣ
                Authorization = new[]
                {
                    filter
                },
                IsReadOnlyFunc = Context =>
                {
                    return false;//�Ƿ�ֻ�����
                }
            };

            app.UseHangfireDashboard("/job", options); //���Ըı�Dashboard��url
            HangfireDispose.HangfireService();

            #endregion

            app.UseHangfireServer();
            app.UseHangfireDashboard();


            app.Map("/index", r =>
            {
                r.Run(context =>
                {
                    //����ÿ����ִ��һ��
                    RecurringJob.AddOrUpdate(() => Console.WriteLine($"ASP.NET Core LineZero"), Cron.Minutely());
                    return context.Response.WriteAsync("ok");
                });
            });

            // �ȿ�����֤
            app.UseAuthentication();

            // Ȼ������Ȩ�м��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // ע����Program.CreateHostBuilder�����Autofac���񹤳�
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
