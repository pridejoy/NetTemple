using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace 表达式树
{
    class Program
    {
        static void Main(string[] args)
        {
            SetviceTest setviceTest = new SetviceTest() { Name = "cxd", Age = 18 };
            #region 表达式树获取属性值
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                var t = Expression.Property(Expression.Constant(setviceTest),
                "Name");
                var g = Expression.Lambda<Func<object>>(t).Compile()();
                stopwatch.Stop();
                Console.WriteLine("表达式树取值" + g + "：" + stopwatch.ElapsedMilliseconds);
            }
            #endregion
            #region 反射获取属性值
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                var t = setviceTest.GetType().GetProperty("Name").GetValue(setviceTest);
                stopwatch.Stop();
                Console.WriteLine("反射取值" + t + "：" + stopwatch.ElapsedMilliseconds);
            }
            #endregion
            #region 表达式树调用泛型静态方法
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                var expre = Expression.Call(typeof(TestMethod), "GetT", new Type[] { setviceTest.GetType() });
                var func = Expression.Lambda<Func<object>>(expre).Compile()();
                stopwatch.Stop();
                Console.WriteLine("表达式树调用方法：" + func.ToString() + ";" + stopwatch.ElapsedMilliseconds);
            }
            #endregion
            #region 反射调用泛型静态方法
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                var result = typeof(TestMethod).GetMethod("GetT").MakeGenericMethod(new Type[] { setviceTest.GetType() }).Invoke(null, null);
                stopwatch.Stop();
                Console.WriteLine("反射调用方法：" + result.ToString() + ";" + stopwatch.ElapsedMilliseconds);
            }
            #endregion
            #region 构造表达式树查询条件
            {
                List<SetviceTest> setvices = new List<SetviceTest>();
                setvices.Add(setviceTest);
                var para = Expression.Parameter(setviceTest.GetType(), "p");
                var left = Expression.Property(para, setviceTest.GetType().GetProperty("Name"));
                var leftOne = Expression.Property(para, setviceTest.GetType().GetProperty("Age"));
                var rightOne = Expression.Constant(10);
                var right = Expression.Constant("cxd");
                var funcOne = Expression.GreaterThan(leftOne, rightOne);
                var func = Expression.Equal(left, right);//可以为add  或者其他运算符，根据需求 自行修改
                var body = Expression.And(func, funcOne);
                var resultExpress = Expression.Lambda<Func<SetviceTest, bool>>(body, new ParameterExpression[] { para }).Compile();
                var result = setvices.Where(resultExpress).ToList();
            }
            #endregion
            #region 表达式树创建对象
            {
                var t = Expression.New(setviceTest.GetType());
                var list = new List<object>();
                list.Add("陈显达");
                list.Add(18);
                var t1 = Expression.New(typeof(Setvice).GetConstructors().FirstOrDefault(), list.Select(s => Expression.Constant(s)));
                var instance = Expression.Lambda<Func<SetviceTest>>(t).Compile()();
                var instanceOne = Expression.Lambda<Func<Setvice>>(t1).Compile()();
            }
            #endregion
            #region 反射创建
            {
                var instance = Activator.CreateInstance(setviceTest.GetType());
                var list = new List<object>();
                list.Add("陈显达");
                list.Add(18);
                var instanceOne = Activator.CreateInstance(typeof(Setvice), list.ToArray());
            }
            #endregion
            #region 表达式SwitchCase
            {
                #region 无返回值Switch
                var switchValue = Expression.Constant(20);
                var list = new List<object>();
                list.Add("陈显达");
                list.Add(18);
                var metho = typeof(Setvice).GetMethod("Get");
                var instanceOne = Activator.CreateInstance(typeof(Setvice), list.ToArray());
                SwitchExpression switchExpr = Expression.
                    Switch(switchValue, Expression.Constant(false),
                    new SwitchCase[] {
                        Expression.SwitchCase(Expression.Call(Expression.Constant(list), list.GetType().GetMethod("Contains"), Expression.Constant("我是你爹")), Expression.Constant(18))
                    ,Expression.SwitchCase(Expression.Call(Expression.Constant(list), list.GetType().GetMethod("Remove"), Expression.Constant("陈显达")), Expression.Constant(20))
                    });
                Expression.Lambda<Action>(switchExpr).Compile()();
                #endregion
                #region 带返回值
                var value = Expression.Constant("TestValue");

                var action = Expression.Switch(typeof(string), value, Expression.Constant("Default"), typeof(Program).GetMethod("Compare"), new SwitchCase[] {
            Expression.SwitchCase(Expression.Constant("Test"),Expression.Constant("Test")),
              Expression.SwitchCase(Expression.Constant("DefaultValue"),Expression.Constant("DefaultValue")),
                Expression.SwitchCase(Expression.Constant(value.Value),Expression.Constant("TestValue"))
            });
                var result = Expression.Lambda<Func<string>>(action).Compile()();
                Console.WriteLine(result);
                #endregion
            }
            #endregion
            #region 表达式TryCatch
            {
                List<ParameterExpression> parameters = new List<ParameterExpression>();
                List<Expression> convertedParameters = new List<Expression>();

                ParameterExpression parameter1 = Expression.Parameter(typeof(object));
                parameters.Add(parameter1);
                convertedParameters.Add(Expression.Convert(parameter1, typeof(int)));

                ParameterExpression parameter2 = Expression.Parameter(typeof(object));
                parameters.Add(parameter2);
                convertedParameters.Add(Expression.Convert(parameter2, typeof(int)));

                SimpleMath simpleMath = new SimpleMath();

                MethodInfo addNumebrsMethodInfo = simpleMath.GetType().GetMethods().Where(x => x.Name == "AddNumbers").ToArray()[0];
                MethodCallExpression returnMethodWithParameters = Expression.Call(Expression.Constant(simpleMath), addNumebrsMethodInfo, convertedParameters);

                UnaryExpression returnMethodWithParametersAsObject = Expression.Convert(returnMethodWithParameters, typeof(object));
                TryExpression tryCatchMethod = Expression.TryCatch(returnMethodWithParameters, Expression.Catch(typeof(Exception), Expression.Constant(55, typeof(int))));
                Func<object, object, int> func = Expression.Lambda<Func<object, object, int>>(tryCatchMethod, parameters).Compile();
                object resultVal = func(20, "");
            }
            #endregion
            Console.ReadKey();
        }
        static bool Compare(string a, string b)
        {
            return a == b;
        }
    }
    public class SimpleMath
    {
        public int AddNumbers(int number1, int number2)
        {
            return (number1 + number2);
        }
    }
    public class SetviceTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Setvice
    {
        public Setvice(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public static bool Get()
        {
            return false;
        }
    }
    public class TestMethod
    {
        public static string GetT<T>() where T : class
        {
            return "静态泛型调用";
        }
    }
}
