using System;
using System.Reflection;

namespace 特性
{

    //你在工作中用到那些特性
    //Obsolete (标记过期的特性，微软定义好的，可以使vs报错)
    //HttpGet HttpPost  （请求方式）
    //Assemly （配件或程序集）
    //FormBody FormUrl  
    //AuthorizeFilter (mvc 的权限认证)
    // Serizlized  NoSerizlized (序列话)
    //DataContract SericeContract

    class Program
    {
        //Obsolete 特性用来标记一个方法是过时的，这个过时的意思是：你不应该再使用这个方法了，未来框架也会将其剔除，目前也存在其替代方案
        //[Obsolete("This method is obsolete...",true)]



        //特性本身是没有啥用，但是可以通过反射来使用，增加功能，不会破坏原有的封装
        //通过反射，发现特性 --实例化特性--使用特性
        //通过特性获取表名（orm）就是一个很好的案例



        //使用自定意的特性
        [Custom]
        [Custom(123)] //传参数
        [Custom("zhao")]
        [return:Custom("zhao")]
        public static void DoSomeWork()
        {
            Console.WriteLine("特性!");
        }


        //通过反射获取表名
        public static string GetName(Type type)
        {
            if (type.IsDefined(typeof(TableNameAttribute),true))
            {
                TableNameAttribute attribute =(TableNameAttribute)type.GetCustomAttribute(typeof(TableNameAttribute), true);

                return attribute.GetTableName();
            }
            else
            {
              return  type.Name;
            }
        }



        static void Main(string[] args)
        {
            //DoSomeWork();
      
            Type type = typeof(Student);

            var tableName = GetName(type);
            Console.WriteLine(tableName);

            Console.WriteLine("Hello World!");
        }
    }
}
