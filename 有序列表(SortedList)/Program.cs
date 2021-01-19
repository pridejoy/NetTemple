using System;
using System.Collections;

namespace 有序列表_SortedList_
{
    class Program
    {
        static void Main(string[] args)
        {
            //C# SortedList 类实现了 IDictionary 接口 ,集合中的值都是以键值对的形式存取的。

            //C# SortedList 称为有序列表，按照 key 值对集合中的元素排序。

            //SortedList 集合中所使用的属性和方法与 Hashtable  比较类似，这里不再赘述。

            //下面通过实例来演示 SortedList 集合的使用。

            // 【实例】使用 SortedList 实现挂号信息的添加、查找以及遍历操作。

            SortedList sortList = new SortedList();
            sortList.Add(1, "小张");
            sortList.Add(2, "小李");
            sortList.Add(3, "小刘");
            Console.WriteLine("请输入挂号编号：");
            int id = int.Parse(Console.ReadLine());
            bool flag = sortList.ContainsKey(id);
            if (flag)
            {
                string name = sortList[id].ToString();
                Console.WriteLine("您查找的患者姓名为：{0}", name);
            }
            else
            {
                Console.WriteLine("您查找的挂号编号不存在！");
            }
            Console.WriteLine("所有的挂号信息如下：");
            foreach (DictionaryEntry d in sortList)
            {
                int key = (int)d.Key;
                string value = d.Value.ToString();
                Console.WriteLine("挂号编号：{0}，姓名：{1}", key, value);
            }

        }
    }
}
