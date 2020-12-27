using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Nancy.Json;
using Newtonsoft.Json;

namespace Serializations
{
    //一定要加上特性
    [Serializable]
    public class Student
    {
        public int id { get; set; }

        public string Name { get; set; }
    }

    class Program
    {

        //https://www.cnblogs.com/webenh/p/13491861.html
        //
        static void Main(string[] args)
        {

            List<Student> st = new List<Student>
            {
                new Student{id=3,Name="zhangsan"},
                new Student{id=1,Name="lisi"},
                new Student{id=5,Name="wangwu"},
                new Student{id=2,Name="zhao"},
            };

            #region   二进制（流）序列化
            //using System.Runtime.Serialization.Formatters.Binary;



            ////序列化
            //BinaryFormatter bf = new BinaryFormatter();
            //using (FileStream fs = new FileStream("data.bin", FileMode.Create))
            //{
            //    bf.Serialize(fs, st);
            //}

            //反序列化
            //BinaryFormatter bf = new BinaryFormatter();
            //using (FileStream fs = new FileStream("data.bin", FileMode.Open))
            //{
            //    var data = bf.Deserialize(fs) as List<Student>;
            //    foreach (var student in data)
            //    {
            //        Console.WriteLine($"id:{ student.id} Name:{student.Name}");
            //    }
            //}

            #endregion

            #region   SOAP序列化
            //using System.Runtime.Serialization.Formatters.Soap ;


            //Serialization of String Object            
            //string strobj = "test string for serialization";
            //FileStream stream = new FileStream("C:\\StrObj.txt", FileMode.Create, FileAccess.Write,
            //    FileShare.None);
            //SoapFormatter formatter = new SoapFormatter();
            //formatter.Serialize(stream, strobj);
            //stream.Close();
            ////Deserialization of String Object
            //FileStream readstream = new FileStream("C:\\StrObj.txt", FileMode.Open, FileAccess.Read,
            //    FileShare.Read);
            //string readdata = (string)formatter.Deserialize(readstream);
            //readstream.Close();
            //Console.WriteLine(readdata);
            //Console.ReadLine();
            #endregion


            #region XML序列化
            ////using System.Runtime.Serialization.Formatters.Binary;

            ////Serialization of String Object            
            //string strobj = "test string for serialization";
            //FileStream stream = new FileStream("StrObj.txt", FileMode.Create, FileAccess.Write,
            //    FileShare.None);
            //XmlSerializer xmlserializer = new XmlSerializer(typeof(string));
            //xmlserializer.Serialize(stream, strobj);
            //stream.Close();


            ////Deserialization of String Object
            //FileStream readstream = new FileStream("StrObj.txt", FileMode.Open, FileAccess.Read,
            //    FileShare.Read);
            //string readdata = (string)xmlserializer.Deserialize(readstream);
            //readstream.Close();
            //Console.WriteLine(readdata);
            //Console.ReadLine();
            #endregion

            #region  C# json格式的序列化与反序列化
            //https://www.cnblogs.com/zhang1f/p/11093461.html

            #region  1.DataContractJsonSerializer (不推荐)
            ////DataContractJsonSerializer类帮助我们序列化和反序列化Json，他在程序集 System.Runtime.Serialization.dll下的System.Runtime.Serialization.Json命名空间里
            ////序列化
            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Student>));
            //MemoryStream msObj = new MemoryStream();
            ////将序列化之后的Json格式数据写入流中
            //js.WriteObject(msObj, st);
            //msObj.Position = 0;
            ////从0这个位置开始读取流中的数据
            //StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            //string json = sr.ReadToEnd();
            //sr.Close();
            //msObj.Close();
            //Console.WriteLine(json);


            ////反序列化
            //string toDes = json;
            ////string to = "{\"ID\":\"1\",\"Name\":\"曹操\",\"Sex\":\"男\",\"Age\":\"1230\"}";
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            //{
            //    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<Student>));
            //    List<Student> model = (List<Student>)deseralizer.ReadObject(ms);// //反序列化ReadObject
            //    foreach (var item in model)
            //    {
            //        Console.WriteLine("ID=" + item.id);
            //        Console.WriteLine("Name=" + item.Name);
            //    }
            //}
            //Console.ReadKey();
            #endregion


            #region 2.JavaScriptJsonSerializer  （不推荐）

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string jsonData = js.Serialize(st);//序列化
            //Console.WriteLine(jsonData);


            //////反序列化方式一：
            //string desJson = jsonData;
            ////Student model = js.Deserialize<Student>(desJson);// //反序列化
            ////string message = string.Format("ID={0},Name={1},Age={2},Sex={3}", model.ID, model.Name, model.Age, model.Sex);
            ////Console.WriteLine(message);
            ////Console.ReadKey(); 


            //////反序列化方式2
            //dynamic modelDy = js.Deserialize<dynamic>(desJson); //反序列化
            //string messageDy = string.Format("动态的反序列化,ID={0},Name={1},Age={2},Sex={3}",
            //    modelDy["ID"], modelDy["Name"], modelDy["Age"], modelDy["Sex"]);//这里要使用索引取值，不能使用对象.属性
            //Console.WriteLine(messageDy);
            //Console.ReadKey();

            #endregion


            #region 3.JSON.NET(性能最好) 推荐 JsonConvert
            //Json.NET序列化
            string jsonData = JsonConvert.SerializeObject(st);

            Console.WriteLine(jsonData);
            Console.ReadKey();


            //Json.NET反序列化
            string json = @"{ 'Name':'C#','id':'1'}";
            Student descJsonStu = JsonConvert.DeserializeObject<Student>(json);//反序列化
            Console.WriteLine(string.Format("反序列化： ID={0},Name={1}", descJsonStu.id, descJsonStu.Name));
            Console.ReadKey();

            #endregion
            #endregion



            Console.WriteLine("Hello World!");
        }
    }
}
