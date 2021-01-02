using System;
using System.Collections.Generic;
using System.Text;

namespace SharpSix
{
    public class Student
    {
        public int? id { get; set; }
        public string Name { get; }

        public string English { get; }

        //构造函数
        //对只读属性只能通过构造函数对其初始赋值
        public Student(string name, string english)
        {
            Name = name;
            English = english;
        }

        public string FullName=>$"{Name}-{English}";  //gose to

        public string FullName1
        {
            get { return $"{Name}-{English}"; }
            //get { return string.Format("{0}-{1}", Name, English); }
        }

        public string Tostring() => $"{Name}+{English}";
    }
}
