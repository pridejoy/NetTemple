﻿using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    public class Redis
    {
        public static void DoSmaple()
        {
            //教程
            //https://www.cnblogs.com/shiyh/p/8892309.html   

            //封装
            //https://blog.csdn.net/wanlong360599336/article/details/46771477

            //在Redis中存储常用的5种数据类型：String,Hash,List,SetSorted set

            //面试题
            //https://www.redis.com.cn/redis-interview-questions.html

            RedisClient client = new RedisClient("127.0.0.1", 6379);
            //强制刷新所有DB(生成环境请慎用，会清掉所有DB中的key)。
            client.FlushAll();

            #region string
            //设置过期时间 -Add
            client.Add<string>("StringValueTime", "我已设置过期时间噢30秒后会消失", DateTime.Now.AddMilliseconds(30000));
            while (true)
            {
                if (client.ContainsKey("StringValueTime"))
                {
                    Console.WriteLine("String.键:StringValue,值:{0} {1}", client.Get<string>("StringValueTime"), DateTime.Now);
                    Thread.Sleep(10000);
                }
                else
                {
                    Console.WriteLine("键:StringValue,值:我已过期 {0}", DateTime.Now);
                    break;
                }
            }

            client.Add<string>("StringValue", " String和Memcached操作方法差不多");
            Console.WriteLine("数据类型为：String.键:StringValue,值:{0}", client.Get<string>("StringValue"));

            Student stud = new Student() { id = "1001", Name = "李四" };
            client.Add<Student>("StringEntity", stud);
            Student Get_stud = client.Get<Student>("StringEntity");
            Console.WriteLine("数据类型为：String.键:StringEntity,值:{0} {1}", Get_stud.id, Get_stud.Name);
            #endregion



            #region  Hash
            client.SetEntryInHash("HashID", "Name", "张三");
            client.SetEntryInHash("HashID", "Age", "24");
            client.SetEntryInHash("HashID", "Sex", "男");
            client.SetEntryInHash("HashID", "Address", "上海市XX号XX室");

            List<string> HaskKey = client.GetHashKeys("HashID");

            foreach (string key in HaskKey)
            {
                Console.WriteLine("HashID--Key:{0}", key);
            }

            List<string> HaskValue = client.GetHashValues("HashID");
            foreach (string value in HaskValue)
            {
                Console.WriteLine("HashID--Value:{0}", value);
            }

            List<string> AllKey = client.GetAllKeys(); //获取所有的key。
            foreach (string Key in AllKey)
            {
                Console.WriteLine("AllKey--Key:{0}", Key);
            }
            #endregion





            #region List
            /*
             * list是一个链表结构，主要功能是push,pop,获取一个范围的所有的值等，操作中key理解为链表名字。 
             * Redis的list类型其实就是一个每个子元素都是string类型的双向链表。我们可以通过push,pop操作从链表的头部或者尾部添加删除元素，
             * 这样list既可以作为栈，又可以作为队列。Redis list的实现为一个双向链表，即可以支持反向查找和遍历，更方便操作，不过带来了部分额外的内存开销，
             * Redis内部的很多实现，包括发送缓冲队列等也都是用的这个数据结构 
             */
            client.EnqueueItemOnList("QueueListId", "1.张三");  //入队
            client.EnqueueItemOnList("QueueListId", "2.张四");
            client.EnqueueItemOnList("QueueListId", "3.王五");
            client.EnqueueItemOnList("QueueListId", "4.王麻子");
            //得到List的总数
            var q = client.GetListCount("QueueListId");
            for (int i = 0; i < q; i++)
            {
                //会让键值对消失
                Console.WriteLine("QueueListId出队值：{0}", client.DequeueItemFromList("QueueListId"));   //出队(队列先进先出)
            }


            client.PushItemToList("StackListId", "1.张三");  //入栈
            client.PushItemToList("StackListId", "2.张四");
            client.PushItemToList("StackListId", "3.王五");
            client.PushItemToList("StackListId", "4.王麻子");
            var p = client.GetListCount("StackListId");
            for (int i = 0; i < p; i++)
            {
                //会让键值对消失
                Console.WriteLine("StackListId出栈值：{0}", client.PopItemFromList("StackListId"));   //出栈(栈先进后出)
            }


            #endregion

            #region Set无序集合
            /*
             它是string类型的无序集合。set是通过hash table实现的，添加，删除和查找,对集合我们可以取并集，交集，差集
             */
            client.AddItemToSet("Set1001", "小A");
            client.AddItemToSet("Set1001", "小B");
            client.AddItemToSet("Set1001", "小C");
            client.AddItemToSet("Set1001", "小D");
            HashSet<string> hastsetA = client.GetAllItemsFromSet("Set1001");
            foreach (string item in hastsetA)
            {
                Console.WriteLine("Set无序集合ValueA:{0}", item); //出来的结果是无须的
            }

            client.AddItemToSet("Set1002", "小K");
            client.AddItemToSet("Set1002", "小C");
            client.AddItemToSet("Set1002", "小A");
            client.AddItemToSet("Set1002", "小J");
            HashSet<string> hastsetB = client.GetAllItemsFromSet("Set1002");
            foreach (string item in hastsetB)
            {
                Console.WriteLine("Set无序集合ValueB:{0}", item); //出来的结果是无须的
            }

            HashSet<string> hashUnion = client.GetUnionFromSets(new string[] { "Set1001", "Set1002" });
            foreach (string item in hashUnion)
            {
                Console.WriteLine("求Set1001和Set1002的并集:{0}", item); //并集
            }

            HashSet<string> hashG = client.GetIntersectFromSets(new string[] { "Set1001", "Set1002" });
            foreach (string item in hashG)
            {
                Console.WriteLine("求Set1001和Set1002的交集:{0}", item);  //交集
            }

            HashSet<string> hashD = client.GetDifferencesFromSet("Set1001", new string[] { "Set1002" });  //[返回存在于第一个集合，但是不存在于其他集合的数据。差集]
            foreach (string item in hashD)
            {
                Console.WriteLine("求Set1001和Set1002的差集:{0}", item);  //差集
            }

            #endregion

            #region  SetSorted 有序集合
            /*
             sorted set 是set的一个升级版本，它在set的基础上增加了一个顺序的属性，这一属性在添加修改.元素的时候可以指定，
             * 每次指定后，zset(表示有序集合)会自动重新按新的值调整顺序。可以理解为有列的表，一列存 value,一列存顺序。操作中key理解为zset的名字.
             */
            client.AddItemToSortedSet("SetSorted1001", "1.刘仔");
            client.AddItemToSortedSet("SetSorted1001", "2.星仔");
            client.AddItemToSortedSet("SetSorted1001", "3.猪仔");
            List<string> listSetSorted = client.GetAllItemsFromSortedSet("SetSorted1001");
            foreach (string item in listSetSorted)
            {
                Console.WriteLine("SetSorted有序集合{0}", item);
            }
            #endregion

            Console.ReadKey();

        }

        public class Student
        {
            public string id { get; set; }
            public string Name { get; set; }
        }
    }
}
