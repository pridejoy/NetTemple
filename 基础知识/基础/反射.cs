using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.基础
{
    /// <summary>
    ///Reflection
    /// </summary>
    public class 反射
    {
        public static void DoSmaple()
        {
            //反射
            //通过反射方法，遍历成员，并调用成员
            object obj = new Student();
            Type type = obj.GetType();
            Console.WriteLine(type.Namespace); //命名空间
            Console.WriteLine(type.FullName); //完全限定名
            Console.WriteLine(type.Name); //类名


            //方法 GetField() 1.获取所有公开的访问字段
            //GetField(string  fieldName) 2.获取特定名称的字段
            //GetProperties()  3.获取所有公开的属性
            //GetProperty(string propertieName)   4.获取特定名称的属性
            //GetMethods()     5.获取所有公开的方法

            //通过反射更新功能
            // (1)using System.Reflection; //泛着dll的类库
            // (2)Environment.CurrentDirectory 可以动态的获取文件路径 
            // (3) Assembly ass=Assembly.LoadFile("dll的路径");
            // (4)ass.GetTypes(); //获取所有的声明类型  //ass.GetType(string typeName)
            // (5) ass.CreateInstance("FullName(完全限定名)");
            // 最后就进行操作方法或者类


            //1.通过遍历来获取字段
            foreach (var fieldInfo in type.GetFields())
            {
                Console.WriteLine(fieldInfo.Name);
                Console.WriteLine(fieldInfo.FieldType.FullName); //类型
                Console.WriteLine(fieldInfo.FieldType.Namespace);
                fieldInfo.SetValue(obj, 11);
                Console.WriteLine(fieldInfo.GetValue(obj));
            }

            //2.
            type.GetField("age").SetValue(obj, 11);
            Console.WriteLine(type.GetField("age").GetValue(obj));


            //3.
            foreach (var propertyInfo in type.GetProperties())
            {
                Console.WriteLine(propertyInfo.Name);
                Console.WriteLine(propertyInfo.PropertyType.FullName);
                Console.WriteLine(propertyInfo.PropertyType.Namespace);
                propertyInfo.SetValue(obj, 123);
                Console.WriteLine(propertyInfo.GetValue(obj));
            }

            //4.
            type.GetProperty("id").SetValue(obj, 567);
            Console.WriteLine(type.GetProperty("id").GetValue(obj));


            //5.
            foreach (var methodInfo in type.GetMethods())
            {
                //属性的本质是方法 get;set;两个方法
                Console.WriteLine(methodInfo.Name);
            }

            //6.
            type.GetMethod("Show").Invoke(obj, new object[0]);
            type.GetMethod("Show2").Invoke(obj, new object[] { "张三" });

            Console.WriteLine(Environment.CurrentDirectory);
            Assembly ass = Assembly.LoadFile(@"D:\Pride\NetTemple\基础知识\bin\Debug\net5.0\基础知识.dll");
            ass.GetTypes(); //获取所有的声明类型 
            ass.GetType("Main");
            ass.CreateInstance("FullName(完全限定名)");
        }

        class Student
        {
            public int id { get; set; }
            public int age;

            public void Show()
            {
                Console.WriteLine("Show");
            }

            public void Show2(string name)
            {
                Console.WriteLine($"你好{name}");
            }


        }


    }
}
