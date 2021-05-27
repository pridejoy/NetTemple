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
    public class 事件
    {
        public static void DoSmaple()
        {



        }
         //在类的内部声明事件，首先必须声明该事件的委托类型。例如：
        public delegate void BoilerLogHandler(string status);

        // 基于上面的委托定义事件
        public event BoilerLogHandler BoilerEventLog;

    }
}
