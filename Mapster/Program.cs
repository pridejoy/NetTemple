using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Mapster;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Mapster
{
    class Program
    {
        static void Main(string[] args)
        {
            var listUser = new List<User>()
            {
                new User(){Name = "张三",Age = 1},
                new User(){Name = "李四",Age = 2},
                new User(){Name = "李四",Age = 1}
            };



            List<User> racers = new List<User>();
            racers.Add(new User(){ Name = "Jacques", Sex = "男", like = "Canada",Age = 11 });
            racers.Add(new User(){ Name = "Alan", Sex = "女", like = "Australia", Age = 12 });
            racers.Add(new User(){ Name = "Jackie", Sex = "男", like = "United Kingdom", Age = 27 });
            racers.Add(new User(){ Name = "James", Sex = "女", like = "United Kingdom", Age = 10 });
            racers.Add(new User(){ Name = "James", Sex = "女", like = "United Kingdom", Age = 10 });
            racers.Add(new User(){ Name = "Jack", Sex = "女", like = "Australia", Age = 14 });

            Lookup<string, User> lookupRacers = (Lookup<string, User>)
            racers.ToLookup(x=>x.Sex);

            foreach (User r in lookupRacers["Australia"])
            {
                Console.WriteLine(r);
            }

            var aa= racers.GroupBy(x => x.Sex);
           foreach (IGrouping<string, User> item in aa)
           {
               Console.WriteLine(item.Key);

               List<User> sl = item.ToList<User>();//分组后的集合

               foreach (var VARIABLE in sl)
               {
                   Console.WriteLine(item.Key+"--"+VARIABLE.Name);
               }
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
     
        public string Sex { get; set; }
        public string like { get; set; }
        public int Age { get; set; }

    }

    public class UserDto
    {
        public string name { get; set; }
        public int UserAge { get; set; }
        public string UserSex { get; set; }
        public string like { get; set; }
    }
}
