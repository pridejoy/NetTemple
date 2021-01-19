using System;
using System.Collections;
using System.Collections.Generic;

namespace 队列_Queue_
{
    class Program
    {
        static void Main(string[] args)
        {

            //Queue 类不能在创建实例时直接添加值

            //Queue 类提供了 4 个构造方法，如下表所示。

            //构造方法                               |                      作用
            // Queue()                               |   创建 Queue 的实例，集合的容量是默认初始容量 32 个元素，使用默认的增长因子
            //Queue(ICollection col)                 |   创建 Queue 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数、增长因子相同
            //Queue(int capacity)                    |   创建 Queue 的实例，并设置其指定的元素个数，默认增长因子
            //Queue(int capacity, float growFactor)  |   创建 Queue 的实例，并设置其指定的元素个数和增长因子

            //
            //增长因子是指当需要扩大容量时，以当前的容量（capacity）值乘以增长因子（growFactor）的值来自动增加容量。

            //第 1 中构造器
            //Queue queue1 = new Queue();
            ////第 2 中构造器
            //Queue queueq2 = new Queue(queue1);
            ////第 3 中构造器
            //Queue queueq3 = new Queue(30);
            ////第 4 中构造器
            //Queue queueq4 = new Queue(30, 2);



            //常用方法
            //Count                               |  属性，获取 Queue 实例中包含的元素个数
            //void Clear()                        |  清除 Queue 实例中的元素
            //bool Contains(object obj)           |  判断 Queue 实例中是否含有 obj 元素
            //void CopyTo(Array array, int index) |  将 array 数组从指定索引处的元素开始复制到 Queue 实例中
            //object Dequeue()                    |  移除并返回位于 Queue 实例开始处的对象
            //void Enqueue(object obj)            |  将对象添加到 Queue 实例的结尾处
            //object Peek()                       |  返回位于 Queue 实例开始处的对象但不将其移除
            //object[] ToArray()                  |  将 Queue 实例中的元素复制到新数组
            //void TrimToSize()                   |  将容量设置为 Queue 实例中元素的实际数目
            //IEnumerator GetEnumerator()         |  返回循环访问 Queue 实例的枚举数


            //【实例 1】创建 Queue 类的实例，模拟排队购电影票的操作。
            //【实例 2】向 Queue 类的实例中添加 3 个值，在不移除队列中元素的前提下将队列中的元素依次输出。


            //1.
            Queue queue = new Queue();
            queue.Enqueue("张三");
            queue.Enqueue("李四");
            queue.Enqueue("王五");
            Console.WriteLine("排队开始:");
            while (queue.Count!=0)
            {
                Console.WriteLine(queue.Dequeue()+"已购票");
            }

            //2.
            queue.Enqueue("张三");
            queue.Enqueue("李四");
            queue.Enqueue("王五");
            //1).
            //object [] arr = queue.ToArray();
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //2).
            IEnumerator enumerator = queue.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }




        }
    }
}
