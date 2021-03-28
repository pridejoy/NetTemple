using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace 特性
{
    [TableName("t_student")]
    public class Student
    {
        //public  string tablename = "t_student";

        //public string tostring()
        //{
        //    return "t_student";
        //}

        public  int id { get; set; }

        public  string Name { get; set; }
        public  int Sex { get; set; }
    }
}
