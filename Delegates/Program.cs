using System;

namespace Delegates
{

    //委托是引用类型
    //委托的定义（Delegate） 是存有对某个方法的引用的一种  引用类型  变量。
    //委托是封装方法的数据类型

    //定义一个委托 委托需要委托名，返回的参数
    public delegate void MyDelegate();

    public delegate string MyDelegate2(string Name);

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
            //第一个是形参，第二个是返回参数
            //Action<int,int> ac2 = Program.Demo2;
            //ac2(4, 5);


            //第一个是形参，第二个是返回参数
            //Func<int, string> fu = Program.Demo4;
            //Console.WriteLine(fu(6));

            //多播委托
            //Action duobo1 = Duobo;
            //Action duobo2 = Duobo2;
            //Action duobo3 = Duobo3;
            //Action duobo4 = duobo2+duobo2+duobo3;
            //duobo4(); //按照添加的顺序执行


            //
            // 事件在类中声明且生成，且通过使用同一个类或其他类中的委托与事件处理程序关联

            //1.在类的内部声明事件，首先必须声明该事件的委托类型
            EnvenStudent estu = new EnvenStudent();
            estu.OldEnvet += Old_Event;
            estu.YongEnvet += Yon_Event;
            while (true)
            {
                Console.WriteLine("请输入年龄");
                var age = int.Parse(Console.ReadLine());
                if (age <= 0) return ;
                estu.Age = age;
            }


            Console.WriteLine("Hello World!");
        }

        public static void Yon_Event()
        {
            Console.WriteLine("录入年轻的人");
        }

        public static void Old_Event()
        {
            Console.WriteLine("录入年长的");
        }
    }
}
