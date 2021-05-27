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
    public class 密封类或密封方法
    {
        public static void DoSmaple()
        {

            //sealed 关键字的含义是密封的，使用该关键字能修饰类或者类中的方法，修饰的类被称为密封类、修饰的方法被称为密封方法。
            //但是密封方法必须出现在子类中，并且是子类重写的父类方法，即 sealed 关键字必须与 override 关键字一起使用。
            //密封类不能被继承，密封方法不能被重写。
            //
            //在实际应用中，在发布的软件产品里有些类或方法不希望再被继承或重写，
            //可以将其定义为密封类或密封方法。


            //【实例】创建一个计算面积的抽象类 AreaAbstract, 并定义抽象方法计算面积。

            //定义矩形类继承该抽象类，并重写抽象方法，将其定义为密封方法；
            //定义圆类继承该抽象类，并重写抽象方法，将该类定义为密封类。

            Rectangle rectangle = new Rectangle() { Width = 10, Length = 20 };
            rectangle.Area();

            Circle circle = new Circle() { r = 10 };
            circle.Area();


        }
        abstract class AreaAbstract
        {
            public abstract void Area();
        }

        class Rectangle : AreaAbstract
        {
            public double Width { get; set; }
            public double Length { get; set; }
            public sealed override void Area()
            {
                Console.WriteLine("矩形的面积是：" + Width * Length);
            }
        }


        sealed class Circle : AreaAbstract
        {
            public double r { get; set; }
            public override void Area()
            {
                Console.WriteLine("圆的面积是：" + r * 3.14 * 3.14);
            }
        }





    }
}
