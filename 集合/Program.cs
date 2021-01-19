using System;
using System.Collections;

namespace 集合
{
    class Program
    {
        static void Main(string[] args)
        {

            //集合与数组比较类似，都用于存放一组值，但集合中提供了特定的方法能直接操作集合中的数据，并提供了不同的集合类来实现特定的功能。

            //集合简单的说就是数组的升级版。他可以动态的对集合的长度（也就是集合内最大元素的个数）进行定义和维护

            //所有集合类或与集合相关的接口命名空间都是 System.Collection，在该命名空间中提供的常用接口如下表所示。


            //IEnumerable 用于迭代集合中的项，该接口是一种声明式的接口
            //IEnumerator 用于迭代集合中的项，该接口是一种实现式的接口
            //ICollection.NET 提供的标准集合接口，所有的集合类都会直接或间接地实现这个接口
            //IList   继承自 IEnumerable 和 ICollection 接口，用于提供集合的项列表，并允许访问、查找集合中的项
            //IDictionary 继承自 IEnumerable 和 ICollection 接口，与 IList 接口提供的功能类似，但集 合中的项是以键值对的形式存取的
            //IDictionaryEnumerator 用于迭代 IDictionary 接口类型的集合

            //类名称      |                           接口实现                          |                     特点
            //ArrayList   | ICollection、IList、IEnumerable、ICloneable                 |  集合中元素的个数是可变的，提供添加、删除等方法
            //Queue       | ICollection、IEnumerable、ICloneable                        |  集合实现了先进先出的机制，即元素将在集合的尾部添加、在集合的头部移除
            //Stack       | ICollection、IEnumerable、ICloneable                        |  集合实现了先进后出的机制，即元素将在集合的尾部添加、在集合的尾部移除
            //Hashtable   | IDictionary、ICollection、IEnumerable、 ICloneable 等接口   |  集合中的元素是以键值对的形式存放的，是 DictionaryEntry 类型的
            //SortedList  | IDictionary、ICollection、IEnumerable、  ICloneable 等接口  |  与 Hashtable 集合类似，集合中的元素以键值对的形式存放，不同的是该集合会按照 key 值自动对集合中的元素排序


            #region   ArrayList类：动态数组
            //查找集合中是否含有 abc 元素。
            //将集合中元素下标是偶数的元素添加到另一个集合中。
            //在集合中第一个元素的后面任意插入 3 个元素。
            //将集合中的元素使用 Sort 方法排序后输出。
            //【实例 5】定义一个 ArrayList 类型的集合，并在其中任意存放 5 个值，使用 Sort 方法完成排序并输岀结果

            //1
            ArrayList arrayList = new ArrayList() {"asd","qwe","zxc",123,789,234 };
             Console.WriteLine(arrayList.IndexOf(123)); //找到返回索引，没找到返回-1;

            //2
            ArrayList arrayList1 = new ArrayList();
            for (int i = 0; i < arrayList.Count; i=i+2)
            {
                arrayList1.Add(arrayList[i]);
                Console.WriteLine(arrayList[i]);
            }

            //3
            ArrayList arrayList2= new ArrayList() { 15,12,13,14 };
            arrayList.InsertRange(1,arrayList2);

            //4
            arrayList2.Sort();

            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }
            //Sort 方法将集合中的元素按照字母的 ASCII 码从小到大排序，相当于字母的顺序。
            //如果需要将所得到的值按照从大到小的顺序排序，则可以在使用过 Sort 方法后再使用 Reverse 方法将元素倒置。
            //字符串类型的值不能直接使用大于、小于的方式比较，要使用字符串的 CompareTo 方法，该方法的返回值是 int 类型，语法形式如下

            //字符串1.CompareTo(字符串2);
            //当字符串 1 与字符串 2 相等时结果为 0；
            //当字符串 1 的字符顺序在字符串 2 前面时结果为 - 1;
            //当字符串 1 的字符顺序在字符串 2 后面时结果为1。


            //5


            Console.WriteLine("ok");

            #endregion

        }
    }
}
