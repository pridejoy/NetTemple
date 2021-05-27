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
    public class 泛型
    {
        public static void DoSmaple()
        {

            #region  泛型方法

            //实例】创建泛型方法，实现对两个数的求和运算。


            //将T设置为double类型
            Add<double>(3.3, 4);
            //将T设置为int类型
            Add<int>(3, 4);
            #endregion


            #region 泛型类
            MyTest<int> test = new MyTest<int>();
            test.Add(10);
            test.Add(20);
            test.Add(30);
            test.Show();

            #endregion

            #region 泛型集合

            //使用泛型集合 List<T> 实现对学生信息的添加和遍历
            //1.根据题目要求，将学生信息定义为一个类，并在该类中定义学号、姓名、年龄属性。

            //2.使用泛型集合 Dictionary<K,V> 实现学生信息的添加，并能够按照学号查询学生信息。


            //1.
            //定义泛型集合
            List<Student> list = new List<Student>();
            //向集合中存入3名学员
            list.Add(new Student(1, "小明", 20));
            list.Add(new Student(2, "小李", 21));
            list.Add(new Student(3, "小赵", 22));
            //遍历集合中的元素
            foreach (Student stu in list)
            {
                Console.WriteLine(stu);
            }

            //2.
            Dictionary<int, Student> dictionary = new Dictionary<int, Student>();
            Student stu1 = new Student(1, "小明", 20);
            Student stu2 = new Student(2, "小李", 21);
            Student stu3 = new Student(3, "小赵", 22);
            dictionary.Add(stu1.id, stu1);
            dictionary.Add(stu2.id, stu2);
            dictionary.Add(stu3.id, stu3);
            Console.WriteLine("请输入学号：");
            int id = int.Parse(Console.ReadLine());
            if (dictionary.ContainsKey(id))
            {
                Console.WriteLine("学生信息为：{0}", dictionary[id]);
            }
            else
            {
                Console.WriteLine("您查找的学号不存在！");
            }



            #endregion


            #region   IComparable、IComparer接口：比较两个对象的值

            #endregion

        }
        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        //加法运算
        private static void Add<T>(T a, T b)
        {
            double sum = double.Parse(a.ToString()) + double.Parse(b.ToString());
            Console.WriteLine(sum);
        }

        /// <summary>
        /// 泛型类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class MyTest<T>
        {
            private T[] items = new T[3];
            private int index = 0;
            //向数组中添加项
            public void Add(T t)
            {
                if (index < 3)
                {
                    items[index] = t;
                    index++;
                }
                else
                {
                    Console.WriteLine("数组已满！");
                }
            }
            //读取数组中的全部项
            public void Show()
            {
                foreach (T t in items)
                {
                    Console.WriteLine(t);
                }
            }
        }

        /// <summary>
        /// 泛型集合
        /// </summary>
        class Student
        {
            //提供有参构造方法，为属性赋值
            public Student(int id, string name, int age)
            {
                this.id = id;
                this.name = name;
                this.age = age;
            }
            //学号
            public int id { get; set; }
            //姓名
            public string name { get; set; }
            //年龄
            public int age { get; set; }
            //重写ToString 方法
            public override string ToString()
            {
                return id + "：" + name + "：" + age;
            }
        }

    }
}
