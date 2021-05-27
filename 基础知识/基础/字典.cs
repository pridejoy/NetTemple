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
    /// <summary>
    /// Dictionarys
    /// </summary>
    public class 字典
    {
        public class Model
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }

        }
        public static void DoSmaple()
        {
            var asd = new Model() { ID = "213", Name = "123", Level = 2 };


            List<Model> list = new List<Model>() {
                new Model() {ID= "张三", Name= "张三", Level= 2 },
                new Model() {ID= "李四", Name= "李四", Level= 2 },
                new Model() {ID= "213", Name= "123", Level= 2 }
            };

            Dictionary<string, Model> listDic = list.ToDictionary(t => t.ID);


            var model = new Model();

            //存在赋值
            if (listDic.Keys.Contains("张三"))

                model = listDic["张三"];
            Console.WriteLine("Hello World!");


        }

      
	}
}
