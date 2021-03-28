using System;

namespace 事件
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        //在类的内部声明事件，首先必须声明该事件的委托类型。例如：
        public delegate void BoilerLogHandler(string status);

        // 基于上面的委托定义事件
        public event BoilerLogHandler BoilerEventLog;
    }
}
