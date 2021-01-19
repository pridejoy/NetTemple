using System;
using System.Collections;

namespace 哈希表_Hashtable_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hashtable类：哈希表（散列表）
            //C# Hashtable 类实现了 IDictionary 接口，集合中的值都是以键值对的形式存取的。

            //C# 中的 Hashtable 称为哈希表，也称为散列表，在该集合中使用键值对（key/value）的形式存放值。

            //换句话说，在 Hashtable 中存放了两个数组，一个数组用于存放 key 值，一个数组用于存放 value 值。

            //此外，还提供了根据集合中元素的 key 值查找其对应的 value 值的方法。

            //Hashtable 类提供的构造方法有很多，最常用的是不含参数的构造方法，即通过如下代码来实例化 Hashtable 类。

            //Hashtable 对象名 = new Hashtable();

            // 属性或方法                          |  作用
            //Count                                |  集合中存放的元素的实际个数
            //void Add(object key, object value)   |  向集合中添加元素
            //void Remove(object key)              |  根据指定的 key 值移除对应的集合元素
            //void Clear()                         |  清空集合
            //ContainsKey(object key)              |  判断集合中是否包含指定 key 值的元素
            //ContainsValue(object value)          |  判断集合中是否包含指定 value 值的元素


            //【实例】使用 Hashtable 集合实现图书信息的添加、查找以及遍历的操作。

            Hashtable ht = new Hashtable();
            ht.Add(1, "计算机基础");
            ht.Add(2, "C#高级编程");
            ht.Add(3, "数据库应用");
            Console.WriteLine("请输入图书编号");
            int id = int.Parse(Console.ReadLine());
            bool flag = ht.ContainsKey(id);
            if (flag)
            {
                Console.WriteLine("您查找的图书名称为：{0}", ht[id].ToString());
            }
            else
            {
                Console.WriteLine("您查找的图书编号不存在！");
            }

            Console.WriteLine("所有的图书信息如下：");
            foreach (DictionaryEntry d in ht)
            {
                int key = (int)d.Key;
                string value = d.Value.ToString();
                Console.WriteLine("图书编号：{0}，图书名称：{1}", key, value);
            }

        }
    }
}
