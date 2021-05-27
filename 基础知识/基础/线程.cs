using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    public class 线程
    {
        public static void DoSmaple()
        {

            // 在 C# 中使用线程时首先需要创建线程，在使用 Thread 类的构造方法创建其实例时，需要用到 ThreadStart 委托或者 ParameterizedThreadStart 委托创建 Thread 类的实例。
            //ThreadStart 委托只能用于无返回值、无参数的方法，ParameterizedThreadStart 委托则可以用于带参数的方法。

            //【实例 1】使用 ThreadStart 委托创建线程，并定义一个方法输出 0〜10 中所有的偶数。
            ThreadStart ts = new ThreadStart(PrintEven);
            Thread t = new Thread(ts);
            t.Start();

            //【实例 2】在上一实例的基础上添加一个打印 1〜10 中的奇数的方法，再分别使用两个 Thread 类的实例启动打印奇数和偶数的方法。
            ThreadStart ts2 = new ThreadStart(PrintOdd);
            Thread t2 = new Thread(ts2);
            t2.Start();

            //总结：
            //两个线程分别打印了 1〜10 中的奇数和 0〜10 中的偶数，但并不是按照线程的调用顺序先打印出所有的偶数再打印奇数
            //需要注意的是，由于没有对线程的执行顺序和操作做控制，所以运行该程序每次打印的值的顺序是不一样的。
            Console.Read();

        }

        //定义打印0~10中的偶数的方法
        private static void PrintEven()
        {
            for (int i = 0; i <= 1000; i = i + 2)
            {
                //Console.WriteLine(i);
                Console.Write("x");
            }
        }
        //定义打印1~10 中的奇数的方法
        public static void PrintOdd()
        {
            for (int i = 1; i <= 1000; i = i + 2)
            {
                //Console.WriteLine(i);
                Console.Write("y");

            }
        }
    }
}
