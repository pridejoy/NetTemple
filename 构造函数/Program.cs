using System;

namespace 构造函数
{

    public class AClass
    {
        public int i;
        public static int j;
        static AClass()
        {
            j = 2;
            Console.WriteLine("静态构造函数");
        }
        public AClass() : this(5)
        {
            Console.WriteLine("实例构造函数");
        }
        public AClass(int i)
        {
            this.i = i;
            Console.WriteLine("有参数的实例构造函数");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new AClass();
            Console.WriteLine(a.i);
            var b = new AClass(10);
            Console.WriteLine(b.i);
            Console.ReadKey();
        //    静态构造函数
        //        静态构造函数又称类型构造函数，是一个特殊的构造函数，它会在这个类型第一次被实例化或引用任何静态成员之前执行，它具有以下特点：
        //    静态构造函数既没有访问修饰符，也没有参数。
        //    在创建第一个实例或引用任何静态成员之前，将自动调用静态构造函数来初始化类（的类型对象）。静态构造函数只会执行一次。
        //    无法直接调用静态构造函数。它的访问修饰符是 private（不需要写明）。在程序中，用户无法控制何时执行静态构造函数。
        //静态构造函数不应该调用基类型的静态构造函数。这是因为类型不可能有从基类型继承的静态字段。
        //只有在类型包括静态字段且在定义时有赋值动作，C# 才会自动生成一个静态构造函数。

        //    静态构造函数的目的是为了安全地给静态成员赋值。你可以显式定义静态构造函数为静态成员赋值。

        //如果什么都不做，它通过元数据得知这个类型有什么静态成员，并在其中初始化这些静态成员为默认值。

        //静态构造函数默认是没有的。因为它的功能是确定的（为静态字段赋值），而且只运行一次。

        //所以，它不需要访问修饰符和参数。如果没有显式定义，而且，没有在代码中为静态成员赋值，则 C# 不会自动生成静态构造函数。
        }
    }
}
