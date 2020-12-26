#define PI2
using System;

namespace Interface
{
    class Program
    {


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

        //接口案例
        static void Main(string[] args)
        {
            Body body=new Body();
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
    }
}
