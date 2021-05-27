using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    public class 语法
    {
        public static void DoSmaple()
        {
            var args = "";
            // do 语句
            Console.WriteLine("do 语句");
            Console.WriteLine("");
            string s;
            do
            {
                s = Console.ReadLine();
                Console.WriteLine(s);
            } while (s == null);//结束条件


            //break 语句
            Console.WriteLine("break 语句");
            Console.WriteLine("语句用于中断循环，使循环不再执行。如果是多个循环语句嵌套使用，则 break 语句跳出的则是最内层循环");
            while (true)
            {
                string sa = Console.ReadLine();
                if (sa != null) break;
                Console.WriteLine(sa);
            }


            // continue 语句
            Console.WriteLine("continue 语句");
            Console.WriteLine(" continue 语句有点像 break 语句。但它不是强制终止，continue 会跳过当前循环中的代码，强制开始下一次循环");
            for (int ji = 0; ji < args.Length; ji++)
            {
                //if (args[ji].StartsWith("/")) continue;
                Console.WriteLine(args[ji]);
            }

            //C# goto 语句用于直接在一个程序中转到程序中的标签指定的位置，标签实际上由标识符加上冒号构成。

            Console.WriteLine("goto 语句");
            Console.WriteLine(" goto 语句用于直接在一个程序中转到程序中的标签指定的位置，标签实际上由标识符加上冒号构成。");

            int i = 0;
            goto check;
            loop:
            Console.WriteLine(args[i++]);
            check:
            if (i < args.Length) goto loop;
            zhangsan:
            Console.WriteLine("zhangsan");


            Console.WriteLine("yield 语句");
            Console.WriteLine("yield是一个语法糖.yield是在C#中的一个语法糖");
            foreach (int yx in Range(-10, 10))
            {
                Console.WriteLine(yx);
            }


            Console.WriteLine("checked 和 unchecked 语句");
            // checked 和 unchecked 语句
            int x = int.MaxValue;
            //int数据的最大值，当执行checked检测时，就会抛出OverflowException异常。            
           　//在代码中可以用checked和unchecked关键字选择性打开和关闭程序一个特定部分的整数溢出检查，这些关键字将覆盖项目的编译器选项
            //checked关键字是打开运算溢出检查，unchecked相反      
            //unchecked就会强制不检查溢出的代码块。就不会抛出OverflowException这个异常
            unchecked
            {
                Console.WriteLine(x + 1); // Overflow
            }
            checked
            {
                //Console.WriteLine(x + 1); // Exception
            }

            //using 语句
            //用完就直接释放

            using (TextWriter w = File.CreateText("test.txt"))
            {
                w.WriteLine("Line one");
                w.WriteLine("Line two");
                w.WriteLine("Line three");
            }


        }

        // yield 语句
        static IEnumerable<int> Range(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                yield return i;
            }
            yield break;
        }
    }


}
