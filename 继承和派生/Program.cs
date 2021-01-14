using System;

namespace 继承和派生
{
    class Program
    {
        static void Main(string[] args)
        {
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



            //一个类只能有一个父类，但是一个父类可以有多个子类，并且在 C# 语言中继承 关系具有传递性，即 A 类继承 B 类、C 类继承 A 类，则 C 类也相当于继承了 B 类


            //类图主要关系有：泛化（Generalization）,  实现（Realization），关联（Association)，聚合（Aggregation），组合(Composition)，依赖(Dependency)


        }

        class Student { };
    }
}
