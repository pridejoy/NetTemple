using System;

namespace 接口
{
    class Program
    {
        static void Main(string[] args)
        {

            //类之间的继承关系仅支持单重继承，而接口是为了实现多重继承关系设计的

            // 一个类能同时实现多个接口，还能在实现接口的同时再继承其他类，并且接口之间也可以继承。

            //无论是表示类之间的继承还是类实现接口、接口之间的继承，都使用“:”来表示。

            //接口定义的语法形式如下。
            //interface 接口名称
            // {
            //            接口成员；
            //}

            // 1) 接口名称
            //通常是以 I 开头，再加上其他的单词构成。例如创建一个计算的接口，可以命名为 ICompute。
            //2) 接口成员
            //接口中定义的成员与类中定义的成员类似。

            //接口中定义的成员必须满足以下要求。
            //接口中的成员不允许使用 public、private、protected、internal 访问修饰符。
            //接口中的成员不允许使用 static、virtual、abstract、sealed 修饰符。
            //在接口中不能定义字段。
            //在接口中定义的方法不能包含方法体。

            // 【实例】创建一个接口计算学生成绩的接口 ICompute, 并在接口中分别定义计算总成绩、平均成绩的方法。

            //根据题目要求，在该接口中定义学生的学号、姓名的属性，并定义计算成绩的总分和 平均分的方法。
            Student st = new Student() { id = 1, Name = "zhangsan", Math = 90,English=80 };
            Console.WriteLine(st.SumScore());
            Console.WriteLine(st.AvgScore());
            //            接口                                                                                                                              抽象类
            //在接口中仅能定义成员，但不能有具体的实现。	                                                                            抽象类除了抽象成员以外，其他成员允许有具体的实现。
            //在接口中不能声明字段，并且不能声明任何私有成员，成员不能包含任何修饰符。	                                                        在抽象类中能声明任意成员，并能使用任何修饰符来修饰。
            //接口能使用类或者结构体来继承。	                                                                                                       抽象类仅能使用类继承。
            //在使用类来实现接口时，必须隐式或显式地实现接口中的所有成员，否则需要将实现类定义为抽象类，并将接口中未实现的成员以抽象的方式实现。	在使用类来继承抽象 类时允许实现全部或部分成员，但仅实现其中的部分成员，其实现类必须也定义为抽象类。
            //一个接口允许继承多个接口。	                                                                                                       一个类只能有一个父类。


    }

        public interface ICompute
        {
            /// <summary>
            /// 计算总成绩
            /// </summary>
            /// <returns></returns>
            decimal SumScore();
            /// <summary>
            /// 平均成绩
            /// </summary>
            /// <returns></returns>
            decimal AvgScore();
            
        }
        public class Student : ICompute
        {
            public int id { get; set; }

            public string Name { get; set; }

            public decimal Math { get; set; }

            public decimal English { get; set; }

            /// <summary>
            /// 接口的实现
            /// </summary>
            /// <returns></returns>
            public decimal AvgScore()
            {
                return (this.Math + this.English) / 2;
            }

            public decimal SumScore()
            {
                return this.Math + this.English;
            }
        }
    }
}
