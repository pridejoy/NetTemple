using System;

namespace Delegates
{

    //委托是引用类型
    //委托的定义（Delegate） 是存有对某个方法的引用的一种  引用类型  变量。
    //委托是封装方法的数据类型

    //定义一个委托 委托需要委托名，返回的参数
    public delegate void MyDelegate();

    public delegate void MyDelegate2(int A,int B);

    public delegate string MyDelegate3(string Name);

    class Program
    {
        static void Demo()
        {
            Console.WriteLine($"你好，委托");
        }

        static void Demo2(int a,int b)
        {
            Console.WriteLine($"你好，{a+b}");
        }

        static string Demo3(string Name)
        {
            return $"你好，{Name}";
        }

        static string Demo4(int Age)
        {
            return $"你好，我{Age}岁了";
        }

        #region 多播委托

        static void Duobo()
        {
            Console.WriteLine("1");
        }

        static void Duobo2()
        {
            Console.WriteLine("2");
        }


        static void Duobo3()
        {
            Console.WriteLine("3");
        }



        #endregion


        static void Main(string[] args)
        {
            ////无返回值的
            //MyDelegate md = Program.Demo;
            ////调用委托
            //md();
            //MyDelegate2 md2 = Program.Demo2;
            //md2(3, 2);

            //Action  没有返回值的方法委托类型
            //Func<> 有返回值的方法委托类型

            //调用没有返回值的 方法委托类型
            //Action ac = Program.Demo;
            //ac();
            ////返回的参数
            //Action<int,int> ac2 = Program.Demo2;
            //ac2(4, 5);

            //Func<int, string> fu = Program.Demo4;
            //Console.WriteLine(fu(6));

            //多播委托
            Action duobo1 = Duobo;
            Action duobo2 = Duobo2;
            Action duobo3 = Duobo3;
            Action duobo4 = duobo2+duobo2+duobo3;
            duobo4(); //按照添加的顺序执行




            Console.WriteLine("Hello World!");
        }
    }
}
