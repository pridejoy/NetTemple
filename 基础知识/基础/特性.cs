using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    public class 特性
    {
        /// <summary>
        ///     //你在工作中用到那些特性
        //Obsolete (标记过期的特性，微软定义好的，可以使vs报错)
        //HttpGet HttpPost  （请求方式）
        //Assemly （配件或程序集）
        //FormBody FormUrl  
        //AuthorizeFilter (mvc 的权限认证)
        // Serizlized  NoSerizlized (序列话)
        //DataContract SericeContract
        /// </summary>
        public static void DoSmaple()
        {
            //DoSomeWork();

            Type type = typeof(Student);

            var tableName = GetName(type);
            Console.WriteLine(tableName);

            Console.WriteLine("Hello World!");


        }
        //Obsolete 特性用来标记一个方法是过时的，这个过时的意思是：你不应该再使用这个方法了，未来框架也会将其剔除，目前也存在其替代方案
        //[Obsolete("This method is obsolete...",true)]

        //1.声明
        public class TableNameAttribute : Attribute
        {
            private string _name = null;
            //初始化构造函数
            public TableNameAttribute(string tablename)
            {
                this._name = tablename;
            }

            public string GetTableName()
            {
                return this._name;
            }
        }

        //特性本身是没有啥用，但是可以通过反射来使用，增加功能，不会破坏原有的封装
        //通过反射，发现特性 --实例化特性--使用特性
        //通过特性获取表名（orm）就是一个很好的案例



        //使用自定意的特性
        [Custom]
        [Custom(123)] //传参数
        [Custom("zhao")]
        [return: Custom("zhao")]
        public static void DoSomeWork()
        {
            Console.WriteLine("特性!");
        }


        //通过反射获取表名
        public static string GetName(Type type)
        {
            if (type.IsDefined(typeof(TableNameAttribute), true))
            {
                TableNameAttribute attribute = (TableNameAttribute)type.GetCustomAttribute(typeof(TableNameAttribute), true);

                return attribute.GetTableName();
            }
            else
            {
                return type.Name;
            }
        }

        [TableName("t_student")]
        public class Student
        {
            //public  string tablename = "t_student";

            //public string tostring()
            //{
            //    return "t_student";
            //}

            public int id { get; set; }

            public string Name { get; set; }
            public int Sex { get; set; }
        }


        /// <summary>
        /// 客户的特性类
        /// </summary>
        /// AttributeTargets.All --可以修饰的应用属性
        /// AllowMultiple = true   ---是否可以进行多次修饰
        /// Inherited 是否支持继承
        ///AttributeTargets的参数 https://docs.microsoft.com/zh-cn/dotnet/api/system.attributetargets?redirectedfrom=MSDN&view=netcore-3.1

        [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
        public class CustomAttribute : Attribute
        {
            //特性：直接或者间接的继承 Attribute 类
            //定义完就直接可以在方法前面用 [CustomAttribute] 可以省略 Attribute 写成[Custom]

            //下面还可以进行函数的构造

            //public static string Name = "";

            //public static int Age { get; set; }
            public CustomAttribute()
            {
                Console.WriteLine($"特性的构造");
            }

            public CustomAttribute(int a)
            {
                Console.WriteLine($"特性的构造,我是数字{a}");
            }

            public CustomAttribute(string a)
            {
                Console.WriteLine($"特性的构造,我是字母{a}");
            }
        }
    }
}
