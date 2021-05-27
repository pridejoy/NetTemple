using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 基础知识
{
    /// <summary>
    /// Asynchronous
    /// </summary>
    public class 继承和派生
    {
        public static void DoSmaple()
        {

            #region 继承

            //C# 继承的特点
            //    派生类是对基类的扩展，派生类可以添加新的成员，但不能移除已经继承的成员的定义。
            //继承是可以传递的。如果 C 从 B 中派生，B 又从 A 中派生，那么 C 不仅继承了 B 中声明的成员，同样也继承了 A 中声明的成员。
            //构造函数和析构函数不能被继承，除此之外其他成员能被继承。基类中成员的访问方式只能决定派生类能否访问它们。
            //派生类如果定义了与继承而来的成员同名的新成员，那么就可以覆盖已继承的成员，但这并不是删除了这些成员，只是不能再访问这些成员。
            //类可以定义虚方法、虚属性及虚索引指示器，它的派生类能够重载这些成员，从而使类可以展示出多态性。
            //派生类只能从一个类中继承，可以通过接口来实现多重继承。



            //在 Object 类中提供了 4 个常用的方法，即 Equals、GetHashCode、GetType 以及 ToString 方法。

            //1. Equals 方法主要用于比较两个对象是否相等，如果相等则返回 True,否则返回 False。
            //如果是引用类型的对象，则用于判断两个对象是否引用了同一个对象。
            //用法
            //Equals(object ol, object o2); //静态方法
            //Equals(object o); //非静态方法

            Student stu1 = new Student();
            Student stu2 = new Student();
            bool flag = Equals(stu1, stu2);
            Console.WriteLine("stu1 和 stu2 比较的结果为，{0}", flag);


            Student stu3 = stu1;
            Console.WriteLine("stu1 和 stu3 比较的结果为，{0}", stu1.Equals(stu3));

            //2. GetHashCode 方法返回当前 System.Object 的哈希代码，每个对象的哈希值都是固定的
            //不同实例的哈希值是不同的，因此也可以通过该方法比较对象是否相等
            Console.WriteLine("stu1的哈希代码是{0}", stu1.GetHashCode());
            Console.WriteLine("stu2的哈希代码是{0}", stu2.GetHashCode());
            Console.WriteLine("stu3的哈希代码是{0}", stu3.GetHashCode());


            //3. GetType 方法用于获取当前实例的类型，返回值为 System.Type 类型。
            //GetType 方法不含任何参数，是非静态方法
            int i = 100;
            string str = "abc";
            Console.WriteLine(i.GetType());
            Console.WriteLine(str.GetType());
            Console.WriteLine(stu1.GetType());
            #endregion


            #region 类试图的使用

            //一个类只能有一个父类，但是一个父类可以有多个子类，并且在 C# 语言中继承 关系具有传递性，即 A 类继承 B 类、C 类继承 A 类，则 C 类也相当于继承了 B 类


            //类试图的使用
            //https://blog.csdn.net/qq_40732336/article/details/112648068

            //类图主要关系有：泛化（Generalization）,  实现（Realization），关联（Association)，聚合（Aggregation），组合(Composition)，依赖(Dependency)


            #endregion



            #region 枚举
            //枚举类型是一种值类型，定义好的值会存放到栈中
            //枚举类型在定义时使用 enum 关键字表示，枚举类型的定义与类成员的定义是一样的，或者直接定义在命名空间中。


            //1.访问修饰符
            //与类成员的访问修饰符一样，省略访问修饰符也是代表使用 private 修饰符的
            //2.数据类型
            //指枚举中值的数据类型。只能是整数类型，包括 byte、short、int、long 等。
            //3.值1、值2、……
            //在枚举类型中显示的值。但实际上每个值都被自动赋予了一个整数类型值，并且值是递增加 1 的，默认是从 0 开始的，也就是值 1 的值是 0、值 2 的值是 1。

            Console.WriteLine(Title.助教 + "：" + (int)Title.助教);
            Console.WriteLine(Title.讲师 + "：" + (int)Title.讲师);
            Console.WriteLine(Title.副教授 + "：" + (int)Title.副教授);
            Console.WriteLine(Title.教授 + "：" + (int)Title.教授);
            #endregion



            #region 结构体
            //结构体与类比较相似，由于它是值类型，在使用时会比使用类存取的速度更快，但灵活性方面没有类好。
            //结构体从字面上来理解是指定义一种结构，实际上结构体是一种与类的定义非常相似的数据类型，但它是值类型。
            //结构体的定义位置与枚举类型一样，都是在类中定义或者在命名空间下定义，而不能将其定义到方法中。
            //在结构体中能定义字段、属性、方法等成员。定义的语法形式如下。

            //访问修饰符  struct 结构体名称
            //{
            //    //结构体成员
            //}

            //调用结构体的代码可以看出，调用结构体和调用类是类似的，是通过构造器来实现的


            //           结构体                           |          类
            //允许不使用new对其实例化                     |    必须使用new实例化
            //没有默认构造方法                            |      有默认构造方法
            //不能继承类                                  |          能继承类
            //没有析构方法                                |          有析构方法
            //不允许使用abstract、protected以及sealed修饰 |     允许使用abstract、protected以及sealed修饰







            #endregion



            Person person = new Person();
            Console.WriteLine("Person类的Print方法打印内容");
            person.Print();
            Student student = new Student();
            Console.WriteLine("Student类的Print方法打印内容");
            student.Print();
            Teacher teacher = new Teacher();
            Console.WriteLine("Teacher类的Print方法打印内容");
            teacher.Print();

            //用户在程序中会遇到 this 和 base 关键字，this 关键字代表的是当前类的对象，而 base 关键字代表的是父类中的对象。





            #region  virtual（虚拟）

            //virtual 是虚拟的含义，默认情况下类中的成员都是非虚拟的，通常将类中的成员定义成虚拟的，表示这些成员将会在继承后重写其中的内容。
            //virtual 关键字能修饰方法、属性、索引器以及事件等，用到父类的成员中。
            //virtual 关键字不能修饰使用 static 修饰的成员

            //语法
            //修饰属性
            //public virtual 数据类型 属性名 { get; set; }

            //修饰方法
            //访问修饰符  virtual 返回值类型方法名
            //{
            //    语句块；
            //}


            #endregion

        }

        class Person
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Cardid { get; set; }
            public string Tel { get; set; }
            public void Print()
            {
                Console.WriteLine("编号：" + Id);
                Console.WriteLine("姓名：" + Name);
                Console.WriteLine("性别：" + Sex);
                Console.WriteLine("身份证号：" + Cardid);
                Console.WriteLine("联系方式：" + Tel);
            }
        }



        class Student : Person
        {
            public string Major { get; set; }
            public string Grade { get; set; }
            public void Print()
            {
                Console.WriteLine("专业：" + Major);
                Console.WriteLine("年级：" + Grade);
            }

        }


        //继承person
        class Teacher : Person
        {
            public string Title { get; set; }
            public string WageNo { get; set; }
            public void Print()
            {
                Console.WriteLine("职称：" + Title);
                Console.WriteLine("工资号：" + WageNo);
            }
        }

        //枚举

        //    访问修饰符  enum 变量名 : 数据类型
        //{
        //    值l,
        //    值2,
        //}

        // 在定义枚举类型时，要保证枚举值的唯一性，以免影响枚举类型的应用
        public enum Title : int
        {
            助教,
            讲师,
            副教授,
            教授
        }



        //结构体
        struct student
        {
            private string name;
            private int age;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    else
                    {
                        age = value;
                    }
                }
            }
        }
    }
}
