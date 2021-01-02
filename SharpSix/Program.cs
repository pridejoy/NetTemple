using System;

namespace SharpSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student("张三","zhangsan");
            Console.WriteLine(st.FullName);
            Console.WriteLine(st.FullName1);
        }
    }
}
