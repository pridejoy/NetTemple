using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.基础
{
    /// <summary>
    /// Delegalte
    /// </summary>
    public class 委托
    {
        public static void DoSmaple()
        {

            //类的实例话称为对象
            //委托的实例称为委托实例




            //使用1.先声明，在实例
            //委托（Delegate）特别用于实现事件和回调方法。所有的委托（Delegate）都派生自 System.Delegate 类
            //将方法作为变量来处理

            //无参无返回值
            MyDelegate2 h;
            h = SayHi;//不用带括号
            h();
            h();

            //有参返回int类型
            MyDelegate myde;
            myde = SayInt;
            myde(1);
            myde(1);
            myde(1);
            myde(2);

            //委托的简化

            //形参和返回类型一致
            //形参微软定义到
            //返回类型的微软定义两种（自定义的返回类型，和void返回类型）

            //有返回值 -Func<> 无返回值- Action<>
            //前面的为参数，后面的为返回

            Action action;
            action = SayHi;
            action();
            Func<int, int, string> func;
            func = SayInt;
            var a = func(567, 123);
            Console.WriteLine(a);




            Console.WriteLine("Hello World!");

        }

        public static void SayHi()
        {
            Console.WriteLine("你好");
        }

        public static int SayInt(int a)
        {
            Console.WriteLine($"我是{a}");
            return a;
        }

        public static string SayInt(int a, int b)
        {
            Console.WriteLine($"我是{a}和{b}");
            return $"我是{a}和{b}";
        }

        //委托的定义级别很高，和自定义类型一个级别

        public delegate int MyDelegate(int s);

        public delegate void MyDelegate2();
    }
}
