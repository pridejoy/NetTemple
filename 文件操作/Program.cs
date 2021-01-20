using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 文件操作
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Driveinfo：获取计算机驱动器信息

            //查看计算机驱动器信息主要包括查看磁盘的空间、磁盘的文件格式、磁盘的卷标等，在 C# 语言中这些操作可以通过 Driveinfo 类来实现。

            //Driveinfo 类是一个密封类，即不能被继承，其仅提供了一个构造方法，语法形式如下。

            //Driveinfo driveInfo=new Driveinfo("C");


            //属性或方法                 |      作用
            //AvailableFreeSpace         |  只读属性，获取驱动器上的可用空闲空间量(以字节为单位)
            //DriveFormat                |  只读属性，获取文件系统格式的名称，例如 NTFS 或 FAT32
            //DriveType                  |  只读属性，获取驱动器的类型，例如 CD-ROM、可移动驱动器、网络驱动器或固定驱动器
            //IsReady                    |  只读属性，获取一个指示驱动器是否已准备好的值，True 为准备好了， False 为未准备好
            //Name                       |  只读属性，获取驱动器的名称，例如 C:\
            //RootDirectory              |  只读属性，获取驱动器的根目录
            //TotalFreeSpace             |  只读属性，获取驱动器上的可用空闲空间总量(以字节为单位)
            //TotalSize                  |  只读属性，获取驱动器上存储空间的总大小(以字节为单位)
            //VolumeLabel                |  属性， 获取或设置驱动器的卷标
            //Driveinfo[] GetDrives()    |  静态方法，检索计算机上所有逻辑驱动器的驱动器名称

            //【实例 1】获取 D 盘中的驱动器类型、名称、文件系统名称、可用空间以及总空间大小。
            DriveInfo driveInfo = new DriveInfo("D");
            Console.WriteLine("驱动器的名称：" + driveInfo.Name);
            Console.WriteLine("驱动器类型：" + driveInfo.DriveType);
            Console.WriteLine("驱动器的文件格式：" + driveInfo.DriveFormat);
            Console.WriteLine("驱动器中可用空间大小：" + driveInfo.TotalFreeSpace);
            Console.WriteLine("驱动器总大小：" + driveInfo.TotalSize);


            //【实例 2】获取计算机中所有驱动器的名称和文件格式。
            DriveInfo[] driveInfo2 = DriveInfo.GetDrives();
            foreach (DriveInfo d in driveInfo2)
            {
                if (d.IsReady)
                {
                    Console.WriteLine("驱动器名称：" + d.Name);
                    Console.WriteLine("驱动器的文件格式" + d.DriveFormat);
                }
            }



            #endregion


            #region  Directoryinfo类：文件夹操作
            //DirectoryInfo 类能创建该类的实例，通过类的实例访问类成员。

            //DirectoryInfo 类提供了一个构造方法，语法形式如下。
            //DirectoryInfo(string path)

            //在这里 path 参数用于指定文件的目录，即路径。

            //例如创建路径为 D 盘中的 test 文件夹的实例，代码如下。
            //DirectoryInfo directoryInfo = new DirectoryInfo("D:\\test");

            //需要注意的是路径中如果使用 \，要使用转义字符来表示，即 \\；或者在路径中将 \ 字符换成 /。

            //DirectoryInfo 类中常用的属性和方法如下表所示

            // 属性或方法                                                                 |              作用
            //Exists                                                                      |        只读属性，获取指示目录是否存在的值
            //Name                                                                        |        只读属性，获取 Directorylnfo 实例的目录名称
            //Parent                                                                      |        只读属性，获取指定的子目录的父目录
            //Root                                                                        |        只读属性，获取目录的根部分
            //void Create()                                                               |        创建目录
            //DirectoryInfo CreateSubdirectory(string path)                               |        在指定路径上创建一个或多个子目录
            //void Delete()                                                               |        如果目录中为空，则将目录删除
            //void Delete(bool recursive)                                                 |        指定是否删除子目录和文件，如果 recursive 参数的值为 True，则删除，否则不删除
            //IEnumerable<DirectoryInfo> EnumerateDirectories()                           |        返回当前目录中目录信息的可枚举集合
            //IEnumerable<DirectoryInfo> EnumerateDirectories(string searchPattern)       |        返回与指定的搜索模式匹配的目录信息的可枚举集合
            //IEnumerable<FileInfo> EnumerateFiles()                                      |        返回当前目录中的文件信息的可枚举集合
            //IEnumerable<FileInfo> EnumerateFiles(string searchPattern)                  |        返回与搜索模式匹配的文件信息的可枚举集合
            //IEnumerable<FileSystemInfo> EnumerateFileSystemInfos()                      |        返回当前目录中的文件系统信息的可枚举集合
            //IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(string searchPattern)  |        返回与指定的搜索模式匹配的文件系统信息的可枚举集合
            //DirectoryInfo[] GetDirectories()                                            |        返回当前目录的子目录
            //DirectoryInfo[] GetDirectories(string searchPattern)                        |        返回匹配给定的搜索条件的当前目录
            //FileInfo[] GetFiles()                                                       |        返回当前目录的文件列表
            //FileInfo[] GetFiles(string searchPattern)                                   |        返回当前目录中与给定的搜索模式匹配的文件列表
            //FileSystemInfo[] GetFileSystemInfos()                                       |        返回所有文件和目录的子目录中的项
            //FileSystemInfo[] GetFileSystemInfos(string searchPattern)                   |        返回与指定的搜索条件匹配的文件和目录的子目录中的项
            //void MoveTo(string destDirName)                                             |        移动 DirectoryInfo 实例中的目录到新的路径


            //【实例 1】在 D 盘下创建文件夹 code，并在该文件夹中创建 code-1和 code-2 两个子文件夹。
            DirectoryInfo directoryInfo = new DirectoryInfo("D:\\code");
            directoryInfo.Create();
            directoryInfo.CreateSubdirectory("code-1");
            directoryInfo.CreateSubdirectory("code-2");

            //【实例 2】查看 D 盘下 code 文件夹中的文件夹
            //DirectoryInfo directoryInfo = new DirectoryInfo("D:\\code");
            IEnumerable<DirectoryInfo> dir = directoryInfo.EnumerateDirectories();
            foreach (var v in dir)
            {
                Console.WriteLine(v.Name);
            }

            //实例 3】将 code 文件夹及其含有的子文件夹删除。
            //如果要删除一个非空文件夹，则要使用 Delete(True) 方法将文件夹中的文件一并删除，否则会岀现“文件夹不为空”的异常
            //DirectoryInfo directoryInfo = new DirectoryInfo("D:\\code");
            directoryInfo.Delete(true);


            //【实例】使用 Directory 类在 D 盘上操作 code 文件夹，要求先判断是否存在该文件夹，如果存在则删除，否则创建该文件夹。
            bool flag = Directory.Exists("D:\\code");
            if (flag)
            {
                Directory.Delete("D:\\code", true);
            }
            else
            {
                Directory.CreateDirectory("D:\\code");
            }

            #endregion


            #region  FileInfo类：文件操作（常用）
            //属性或方法                                                                                 作用
            //Directory                                                                       只读属性，获取父目录的实例
            //DirectoryName                                                                   只读属性，获取表示目录的完整路径的字符串
            //Exists                                                                          只读属性，获取指定的文件是否存在，若存在返回 True，否则返回 False
            //IsReadOnly                                                                      属性，获取或设置指定的文件是否为只读的
            //Length                                                                          只读属性，获取文件的大小
            //Name                                                                            只读属性，获取文件的名称
            //Filelnfo CopyTo(string destFileName)                                            将现有文件复制到新文件，不允许覆盖现有文件
            //Filelnfo CopyTo(string destFileName, bool overwrite)                            将现有文件复制到新文件，允许覆盖现有文件
            //FileStream Create()                                                             创建文件
            //void Delete()                                                                   删除文件
            //void MoveTo(string destFileName)                                                将指定文件移到新位置，提供要指定新文件名的选项
            //Filelnfo Replace(string destinationFileName, string destinationBackupFileName)  使用当前文件对象替换指定文件的内容，先删除原始文件， 再创建被替换文件的备份


            //【实例】在 D 盘的 code 文件夹下创建名为 test1.txt 的文件，并获取该文件的相关属性，然后将其移动到D盘下的 code-1 文件夹中。
            //在D盘下创建code文件夹
            Directory.CreateDirectory("D:\\code");
            FileInfo fileInfo = new FileInfo("D:\\code\\test1.txt");
            if (!fileInfo.Exists)
            {
                //创建文件
                fileInfo.Create().Close();
            }
            fileInfo.Attributes = FileAttributes.Normal;//设置文件属性
            Console.WriteLine("文件路径：" + fileInfo.Directory);
            Console.WriteLine("文件名称：" + fileInfo.Name);
            Console.WriteLine("文件是否只读：" + fileInfo.IsReadOnly);
            Console.WriteLine("文件大小：" + fileInfo.Length);
            //先创建code-1 文件夹
            //将文件移动到code-1文件夹下
            Directory.CreateDirectory("D:\\code-1");
            //判断目标文件夹中是否含有文件test1.txt
            FileInfo newFileInfo = new FileInfo("D:\\code-1\\test1.txt");
            if (!newFileInfo.Exists)
            {
                //移动文件到指定路径
                fileInfo.MoveTo("D:\\code-1\\test1.txt");
            }


            #endregion

            #region File类：文件操作 （常用）
            //属性或方法                          作用
            //DateTime GetCreationTime(string path)   返回指定文件或目录的创建日期和时间
            //DateTime GetLastAccessTime(string path)     返回上次访问指定文件或目录的日期和时间
            //DateTime GetLastWriteTime(string path)  返回上次写入指定文件或目录的日期和时间
            //void SetCreationTime(string path, DateTime creationTime)    设置创建该文件的日期和时间
            //void SetLastAccessTime(string path, DateTime lastAccessTime)    设置上次访问指定文件的日期和时间
            //void SetLastWriteTime(string path, DateTime lastWriteTime)  设置上次写入指定文件的日期和时间

            //在D盘下创建code文件夹
            Directory.CreateDirectory("D:\\code");
            Directory.CreateDirectory("D:\\code-1");
            string path = "D:\\code\\test1.txt";
            //创建文件
            FileStream fs = File.Create(path);
            //获取文件信息
            Console.WriteLine("文件创建时间：" + File.GetCreationTime(path));
            Console.WriteLine("文件最后被写入时间：" + File.GetLastWriteTime(path));
            //关闭文件流
            fs.Close();
            //设置目标路径
            string newPath = "D:\\code-1\\test1.txt";
            //判断目标文件是否存在
            bool flag2 = File.Exists(newPath);
            if (flag2)
            {
                //删除文件
                File.Delete(newPath);
            }
            File.Move(path, newPath);


            #endregion


            #region Path类：文件路径操作(常用)

            //属性或方法                 作用
            //string ChangeExtension(string path, string extension)   更改路径字符串的扩展名
            //string Combine(params string[] paths)   将字符串数组组合成一个路径
            //string Combine(string path1, string path2)  将两个字符串组合成一个路径
            //string GetDirectoryName(string path)    返回指定路径字符串的目录信息
            //string GetExtension(string path)    返回指定路径字符串的扩展名
            //string GetFileName(string path) 返回指定路径字符串的文件名和扩展名
            //string GetFileNameWithoutExtension(string path) 返回不具有扩展名的指定路径字符串的文件名
            //string GetFullPath(string path) 返回指定路径字符串的绝对路径
            //char[] GetInvalidFileNameChars()    获取包含不允许在文件名中使用的字符的数组
            //char[] GetInvalidPathChars()    获取包含不允许在路径名中使用的字符的数组
            //string GetPathRoot(string path) 获取指定路径的根目录信息
            //string GetRandomFileName()  返回随机文件夹名或文件名
            //string GetTempPath()    返回当前用户的临时文件夹的路径
            //bool HasExtension(string path)  返回路径是否包含文件的扩展名
            //bool IsPathRooted(string path)  返回路径字符串是否包含根


            string path2 = "C:\\1.txt";
            Console.WriteLine("不包含扩展名的文件名：" + Path.GetFileNameWithoutExtension(path2));
            Console.WriteLine("文件扩展名：" + Path.GetExtension(path2));
            Console.WriteLine("文件全名：" + Path.GetFileName(path2));
            Console.WriteLine("文件路径：" + Path.GetDirectoryName(path2));
            //更改文件扩展名
            string newPath2 = Path.ChangeExtension(path2, "doc");
            Console.WriteLine("更改后的文件全名：" + Path.GetFileName(newPath2));

            #endregion


            #region 文件流概念
            //在计算机编程中，流就是一个类的对象，很多文件的输入输出操作都以类的成员函数的方式来提供。

            //计算机中的流其实是一种信息的转换。它是一种有序流，因此相对于某一对象，通常我们把对象接收外界的信息输入（Input）称为输入流，相应地从对象向外 输出（Output）信息为输出流，合称为输入 / 输出流（I / O Streams）。

            //对象间进行信息或者数据的交换时总是先将对象或数据转换为某种形式的流，再通过流的传输，到达目的对象后再将流转换为对象数据。

            //所以， 可以把流看作是一种数据的载体，通过它可以实现数据交换和传输。

            //流所在的命名空间也是System.IO，主要包括文本文件的读写、图像和声音文件的读写、二进制文件的读写等。

            //在 System.IO 命名空间中提供了多种类，用于进行文件和数据流的读写操作。

            //要使用这些类，需要在程序的开头包含语句：using System.IO。

            //流是字节序列的抽象概念，例如文件、输入 / 输出设备、内部进程通信管道等。

            //流提供一种向后备存储器写入字节和从后备存储器读取字节的方式。

            //除了和磁盘文件直接相关的文件流以外，流还有多种类型。

            //例如数据流(Stream) 是对串行传输数据的一种抽象表示，是对输入 / 输出的一种抽象。

            //数据有来源和目的地，衔接两者的就是串流对象。用比喻的方式来说或，数据就好比水，串流对象就好比水管，通过水管的衔接，水由一端流向另一端。

            //从应用程序的角度来说，如果将数据从来源取出，可以试用输入(读) 串流，把数据储存在内存缓冲区；如果将数据写入目的地，可以使用输出(写) 串流，把内存缓冲区的数据写入目的地。

            //当希望通过网络传输数据，或者对文件数据进行操作时，首先需要将数据转化为数据流。

            //典型的数据流和某个外部数据源相关，数据源可以是文件、外部设备、内存、网络套接字等。

            //根据数据源的不同，.Net 提供了多个从 Stream 类派生的子类，每个类代表一种具体的数据流类型，比如磁盘文件直接相关的文件流类 FileStream，和套接字相关的网络流类 NetworkStream，和内存相关的内存流类 MemoryStream 等。

            #endregion

            #region StreamReader类：读取文件

            //构造方法    说明
            //StreamReader(Stream stream) 为指定的流创建 StreamReader 类的实例
            //StreamReader(string path)   为指定路径的文件创建 StreamReader 类的实例
            //StreamReader(Stream stream, Encoding encoding)  用指定的字符编码为指定的流初始化 StreamReader 类的一个新实例
            //StreamReader(string path, Encoding encoding)    用指定的字符编码为指定的文件名初始化 StreamReader 类的一个新实例

            //属性或方法 作用
            //Encoding CurrentEncoding    只读属性，获取当前流中使用的编码方式
            //bool EndOfStream    只读属性，获取当前的流位置是否在流结尾
            //void Close()    关闭流
            //int Peek()  获取流中的下一个字符的整数，如果没有获取到字符， 则返回 - 1
            //int Read()  获取流中的下一个字符的整数
            //int Read(char[] buffer, int index, int count)   从指定的索引位置开始将来自当前流的指定的最多字符读到缓冲区
            //string ReadLine()   从当前流中读取一行字符并将数据作为字符串返回
            //string ReadToEnd()  读取来自流的当前位置到结尾的所有字符

            //【实例】读取 D 盘 code 文件夹下 test.txt 文件中的信息。

            //定义文件路径
            string path3 = @"D:\\code\\test.txt";
            //创建 StreamReader 类的实例
            StreamReader streamReader = new StreamReader(path3);
            //判断文件中是否有字符
            while (streamReader.Peek() != -1)
            {
                //读取文件中的一行字符
                string str = streamReader.ReadLine();
                Console.WriteLine(str);
            }
            streamReader.Close();

            #endregion



            #region  StreamWriter类：写入文件

            //            构造方法 说明
            //StreamWriter(Stream stream)     为指定的流创建 StreamWriter 类的实例
            //StreamWriter(string path)   为指定路径的文件创建 StreamWriter 类的实例
            //StreamWriter(Stream stream, Encoding encoding)  用指定的字符编码为指定的流初始化 StreamWriter 类的一个新实例
            //StreamWriter(string path, Encoding encoding)    用指定的字符编码为指定的文件名初始化 StreamWriter 类的一个新实例


            //            属性或方法  作用
            //bool AutoFlush  属性，获取或设置是否自动刷新缓冲区
            //Encoding Encoding 只读属性，获取当前流中的编码方式
            //void Close()    关闭流
            //void Flush()    刷新缓冲区
            //void Write(char value)  将字符写入流中
            //void WriteLine(char value)  将字符换行写入流中
            //Task WriteAsync(char value) 将字符异步写入流中
            //Task WriteLineAsync(char value)     将字符异步换行写入流中





            //【实例】向 D 盘 code 文件夹的 test.txt 文件中写入姓名和手机号码。



            #endregion


            #region FileStream类：文件读写

            //在 C# 语言中文件读写流使用 FileStream 类来表示，FileStream 类主要用于文件的读写，不仅能读写普通的文本文件，还可以读取图像文件、声音文件等不同格式的文件。

            //在创建 FileStream 类的实例时还会涉及多个枚举类型的值， 包括 FileAccess、FileMode、FileShare、FileOptions 等。

            //FileAccess 枚举类型主要用于设置文件的访问方式，具体的枚举值如下。
            //Read：以只读方式打开文件。
            //Write：以写方式打开文件。
            //ReadWrite：以读写方式打开文件。

            //FileMode 枚举类型主要用于设置文件打开或创建的方式，具体的枚举值如下。
            //CreateNew：创建新文件，如果文件已经存在，则会抛出异常。
            //Create：创建文件，如果文件不存在，则删除原来的文件，重新创建文件。
            //Open：打开已经存在的文件，如果文件不存在，则会抛出异常。
            //OpenOrCreate：打开已经存在的文件，如果文件不存在，则创建文件。
            //Truncate：打开已经存在的文件，并清除文件中的内容，保留文件的创建日期。如果文件不存在，则会抛出异常。
            //Append：打开文件，用于向文件中追加内容，如果文件不存在，则创建一个新文件。

            //FileShare 枚举类型主要用于设置多个对象同时访问同一个文件时的访问控制，具体的枚举值如下。
            //None：谢绝共享当前的文件。
            //Read：允许随后打开文件读取信息。
            //ReadWrite：允许随后打开文件读写信息。
            //Write：允许随后打开文件写入信息。
            //Delete：允许随后删除文件。
            //Inheritable：使文件句柄可由子进程继承。

            //FileOptions 枚举类型用于设置文件的高级选项，包括文件是否加密、访问后是否删除等，具体的枚举值如下。
            //WriteThrough：指示系统应通过任何中间缓存、直接写入磁盘。
            //None：指示在生成 System.IO.FileStream 对象时不应使用其他选项。
            //Encrypted：指示文件是加密的，只能通过用于加密的同一用户账户来解密。
            //DeleteOnClose：指示当不再使用某个文件时自动删除该文件。
            //SequentialScan：指示按从头到尾的顺序访问文件。
            //RandomAccess：指示随机访问文件。
            //Asynchronous：指示文件可用于异步读取和写入。


            //            构造方法 说明
            //FileStream(string path, FileMode mode)  使用指定路径的文件、文件模式创建 FileStream 类的实例
            //FileStream(string path, FileMode mode, FileAccess access)   使用指定路径的文件、文件打开模式、文件访问模式创建 FileStream 类的实例
            //FileStream(string path, FileMode mode, FileAccess access, FileShare share)  使用指定的路径、创建模式、读写权限和共享权限创建 FileStream 类的一个新实例
            //FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options) 使用指定的路径、创建模式、读写权限和共享权限、其他 文件选项创建 FileStream 类的实例


            //【实例 1】在 D 盘 code 文件夹的 student.txt 文件中写入学生的学号信息。

            //定义文件路径
            string path4 = @"D:\\code\\student.txt";
            //创建 FileStream 类的实例
            FileStream fileStream = new FileStream(path4, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            //定义学号
            string msg = "1710026";
            //将字符串转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            //向文件中写入字节数组
            fileStream.Write(bytes, 0, bytes.Length);
            //刷新缓冲区
            fileStream.Flush();
            //关闭流
            fileStream.Close();




            #endregion
        }
    }
}
