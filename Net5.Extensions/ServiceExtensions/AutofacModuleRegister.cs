using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using log4net;
using Net5.Common.Helper;
using Net5.Extensions.AOP;
using Net5.Repository.Base;

namespace Net5.Extensions
{
    /// <summary>
    /// 整个 dll 程序集批量注入
    /// </summary>
    public class AutofacModuleRegister : Autofac.Module
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AutofacModuleRegister));

        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();


            #region 带有接口层的服务注入

            var servicesDllFile = Path.Combine(basePath, "Net5.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "Net5.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                //log.Error(msg);
                throw new Exception(msg);
            }



            var cacheType = new List<Type>();

            //日志记录
            builder.RegisterType<BlogLogAOP>();
            cacheType.Add(typeof(BlogLogAOP));
            //缓存
            //builder.RegisterType<BlogCacheAOP>();
            //cacheType.Add(typeof(BlogCacheAOP));

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();//注册仓储

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(cacheType.ToArray());
            //.InstancePerDependency();

            #endregion

        }
    }
}
