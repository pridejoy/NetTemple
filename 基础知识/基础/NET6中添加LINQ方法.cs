using System.Collections.Generic;
using System.Linq;

namespace 基础知识.基础
{
    public class NET6中添加LINQ方法
    {
        public static void DoSmaple()
        {
            //List<object> numbers1 = new List<object>() { 5, 4, "nihao" };
            //int num = 0;
            //numbers1.TryGetNonEnumeratedCount(out num);
            //System.Console.WriteLine(num);


            var list = new List<dynamic>
            {
               new { Id = 1, Property = "value1" },
               new { Id = 2, Property = "value2" },
               new { Id = 3, Property = "value1" },
               new { Id = 4, Property = "value4" },
               new { Id = 5, Property = "value2" },
               new { Id = 6, Property = "value6" },
               new { Id = 7, Property = "value7" },
               new { Id = 8, Property = "value8" },
               new { Id = 9, Property = "value9" }

            };

            var  a=list.ElementAt(^2);


            var list2 = new List<dynamic>
            {
               new { Id = 4, Property = "value4" },
               new { Id = 5, Property = "value2" },
               new { Id = 6, Property = "value6" }
            };

            var distinctList = list2.ExceptBy(list, x => x.Property).ToList();


            System.Console.WriteLine();
        }
    }
}
