using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识
{
     public class 文件和文件夹
    {
        public static void DoSmaple()
        {

            //写入文件
            //FileStream fs= new FileStream("a.txt",FileMode.CreateNew);
            //StreamWriter sw =new StreamWriter(fs);
            //sw.WriteLine("张三");
            //sw.WriteLine("换行");
            //sw.Close();
            //fs.Close();
            //Console.WriteLine("Hello World!");

            //FileStream fs = new FileStream("a.txt", FileMode.Open);
            //StreamReader sr=new StreamReader(fs);
            //sr.Close();
            //Console.WriteLine(sr.ReadToEnd());

            //using 的用法
            //using (FileStream fs=new FileStream("a.txt", FileMode.Open))
            //{
            //    using (StreamReader sr=new StreamReader(fs))
            //    {
            //        Console.WriteLine(sr.ReadLine());
            //    }
            //}  

            //File.WriteAllText("b.txt", "Hello word");
            //Console.WriteLine(File.ReadAllText("b.txt"));

            var writer = File.AppendText("b.txt");
            //writer.WriteLine("张三");
            //writer.Close();

            //if (!File.Exists("b.txt"))
            //{
            //    //不存在
            //    var writer = File.AppendText("b.txt");
            //    writer.WriteLine("");
            //    writer.Close();
            //}
            //else
            //{
            //    File.AppendAllText("b.txt", "追加了内容");
            //}

            //文件的复制
            //File.Copy("b.txt", @"d:\kekong.txt");
            //文件的移动，或者重命名
            //File.Move("b.txt","c.txt");
            //文件的删除
            //File.Delete("c.txt");
            //文件的创建时间
            //File.GetCreationTime("c.txt");
            //更改文件时间
            //File.SetCreationTime("c.txt",DateTime.Now);

            // 1024字节= 千字节 =1kb
            // 1024kb =1M

            FileInfo file = new FileInfo("c.txt");
            //Console.WriteLine(file.Length);    //文件大小
            //Console.WriteLine(file.FullName);  //完全路径
            //Console.WriteLine(file.Extension); //文件后缀

            //创建文件夹
            //if (!Directory.Exists(@"system\code"))
            //{
            //    Directory.CreateDirectory(@"system\code");
            //}

            //得到文件夹下面所有的文件
            //var files = Directory.GetFiles(@"system\code");
            //foreach (var item in files)
            //{
            //    FileInfo fileInfo = new FileInfo(item);
            //    Console.WriteLine(fileInfo.FullName);
            //}

            //foreach (var path in Directory.GetDirectories(@"system\code"))
            //{
            //    DirectoryInfo di = new DirectoryInfo(path);
            //    Console.WriteLine(di.FullName);
            //    Console.WriteLine(path);
            //}

            //Directory.Delete(@"c");//删除文件夹名    //目录里面是空的

            try
            {
                Directory.Delete(@"c");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("文件夹下不是空的");
                if (Console.ReadLine().Trim() == "y")
                {
                    Directory.Delete(@"c", true); //有文件也删除
                }
                throw;
            }


            Console.ReadLine();
        }
    }
}
