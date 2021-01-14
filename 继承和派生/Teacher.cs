using System;
using System.Collections.Generic;
using System.Text;

namespace 继承和派生
{
    //继承person
    class Teacher:Person
    {
        public string Title { get; set; }
        public string WageNo { get; set; }
        public void Print()
        {
            Console.WriteLine("职称：" + Title);
            Console.WriteLine("工资号：" + WageNo);
        }
    }
}
