using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识
{
    public class 抽象类抽象方法
    {
        public static void DoSmaple()
        {
            #region   abstract(抽象)

            //abstract 关键字代表的是抽象的，使用该关键字能修饰类和方法，
            //修饰的方法被称为抽象方法、修饰的类被称为抽象类
            //在定义抽象类时，若使用 abstract 修饰类，将其放到 class 关键字的前面，语法形式如下。
           
            //访问修饰符 abstract class 类名
            //{
            //    //类成员
            //}


            //创建抽象类 ExamResult，并在类中定义数学(Math)、英语(English) 成绩的属性，定义抽象方法计算总成绩。
            //分别定义数学专业和英语专业的学生类继承抽象类 ExamResult，重写计算总成绩的方法并根据科目分数的不同权重计算总成绩。
            //其中，数学专业的数学分数占60 %、英语分数占40 %；
            //英语专业的数学分数占40 %、英语分数占60 %。

            //子类仅能重写父类中的虚方法或者抽象方法，
            //当不需要使用父类中方法的内容时，
            //将其定义成抽象方法，否则将方法定义成虚方法
            MathMajor mathMajor = new MathMajor() { Id = 1, English = 80, Math = 90 };
            mathMajor.Total();
            EnglishMajor englishMajor = new EnglishMajor() { Id = 2, English = 80, Math = 90 };
            englishMajor.Total();



            #endregion
        }

    }

    //抽象类
    abstract class ExamResult
    {
        //学号
        public int Id { get; set; }
        //数学成绩
        public double Math { get; set; }
        //英语成绩
        public double English { get; set; }
        //计算总成绩
        public abstract void Total();
    }

    class MathMajor : ExamResult
    {
        public override void Total()
        {
            double total = Math * 0.6 + English * 0.4;
            Console.WriteLine("学号为" + Id + "数学专业学生的成绩为：" + total);
        }
    }
    class EnglishMajor : ExamResult
    {
        public override void Total()
        {
            double total = Math * 0.4 + English * 0.6;
            Console.WriteLine("学号为" + Id + "英语专业学生的成绩为：" + total);
        }
    }
}
