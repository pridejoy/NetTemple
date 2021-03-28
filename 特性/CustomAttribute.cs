using System;
using System.Collections.Generic;
using System.Text;

namespace 特性
{
    /// <summary>
    /// 客户的特性类
    /// </summary>
    /// AttributeTargets.All --可以修饰的应用属性
    /// AllowMultiple = true   ---是否可以进行多次修饰
    /// Inherited 是否支持继承
    ///AttributeTargets的参数 https://docs.microsoft.com/zh-cn/dotnet/api/system.attributetargets?redirectedfrom=MSDN&view=netcore-3.1

    [AttributeUsage(AttributeTargets.All,AllowMultiple = true, Inherited=true)]
    public  class CustomAttribute:Attribute
    {
        //特性：直接或者间接的继承 Attribute 类
        //定义完就直接可以在方法前面用 [CustomAttribute] 可以省略 Attribute 写成[Custom]

        //下面还可以进行函数的构造

        //public static string Name = "";

        //public static int Age { get; set; }
        public CustomAttribute( )
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
