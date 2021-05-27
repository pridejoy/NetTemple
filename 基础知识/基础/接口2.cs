using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.基础
{

    /// <summary>
    /// Interface
    /// </summary>
    public class 接口2
    {
        public static void DoSmaple()
        {
            Body body = new Body();
            //body.Name = "张三";
            //body.Eat();
            //body.SayHi("李四");

            //域处理器

#if (PI)
            Console.WriteLine("PI is defined");
#else
            Console.WriteLine("PI is not defined");
#endif
            Console.ReadKey();

            //Console.WriteLine("Hello World!");


        }
        public interface IPerson
        {
            string Name { get; set; }
            void Eat();
            void SayHi(string name);

        }

        public class Body : IPerson
        {
            public string Name { get; set; }

            public void Eat()
            {
                Console.WriteLine("正吃东西");
            }

            public void SayHi(string name)
            {
                Console.WriteLine($"你好，{name}");
            }
        }

    }
}
