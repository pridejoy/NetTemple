using System;
using System.IO;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            FileStream fs= new FileStream("a.txt",FileMode.CreateNew);
            StreamWriter sw =new StreamWriter(fs);
            sw.WriteLine("张三");
            sw.WriteLine("换行");
            sw.Close();
            fs.Close();
            Console.WriteLine("Hello World!");
        }
    }
}
