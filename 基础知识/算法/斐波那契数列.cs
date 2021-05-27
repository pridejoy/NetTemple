using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.算法
{
     public  class 斐波那契数列
    {
        public static void DoSmaple()
        {

            //1.简单入门

            //1.概念
            //斐波那契数列（Fibonacci sequence），又称黄金分割数列、因数学家莱昂纳多·斐波那契（Leonardoda Fibonacci）
            //以兔子繁殖为例子而引入，故又称为“兔子数列”，指的是这样一个数列：1、1、2、3、5、8、13、21、34、
            //……在数学上，斐波那契数列以如下被以递推的方法定义：
            // 表达式:   F[n]=F[n-1]+F[n-2](n>=2,F[0]=0,F[1]=1)
            //这个数列从第3项开始，每一项都等于前两项之和。

            //2.百度百科
            //https://baike.baidu.com/item/%E6%96%90%E6%B3%A2%E9%82%A3%E5%A5%91%E6%95%B0%E5%88%97/99145?fr=aladdin
            //

            //第几位是
            //Console.WriteLine(GetiNum(8));
            //前几位的和
            //Console.WriteLine(GetSum(4));

            //进阶 -四种方法
            //https://www.cnblogs.com/zhaoliankun/p/9149555.html

            ulong result;

            int number = 50;
            Console.WriteLine("************* number={0} *************", number);

            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            result = F1(number);
            watch1.Stop();
            Console.WriteLine("F1({0})=" + result + "  耗时：" + watch1.Elapsed, number);

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            result = F2(number);
            watch2.Stop();
            Console.WriteLine("F2({0})=" + result + "  耗时：" + watch2.Elapsed, number);

            Stopwatch watch3 = new Stopwatch();
            watch3.Start();
            result = F3(number);
            watch3.Stop();
            Console.WriteLine("F3({0})=" + result + "  耗时：" + watch3.Elapsed, number);

            Stopwatch watch4 = new Stopwatch();
            watch4.Start();
            double result4 = F4(number);
            watch4.Stop();
            Console.WriteLine("F4({0})=" + result4 + "  耗时：" + watch4.Elapsed, number);

            Console.WriteLine();

            Console.WriteLine("结束");
            Console.ReadKey();

        }

        #region 基础方法

        /// <summary>
        /// 得到第i项的值(I>0)
        /// </summary>
        /// <param name="i">第i项</param>
        /// <returns>表达式:   F[n]=F[n-1]+F[n-2](n>=2,F[0]=0,F[1]=1)</returns>
        public static int GetiNum(int i)
        {
            if (i == 0)
                return 0;
            if (i == 1 || i == 2)
                return 1;
            return GetiNum(i - 1) + GetiNum(i - 2);

        }

        /// <summary>
        /// 前N项之和
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int GetSum(int N)
        {
            var Sum = 0;
            if (N == 1)
                return 1;
            else if (N == 2)
                return 2;
            else
            {
                for (int i = N; i >= 0; i--)
                {
                    //Console.WriteLine(i+"---"+GetiNum(i));
                    Sum += GetiNum(i);
                }

                return Sum;
            }
        }
        #endregion


        #region 迭代法
        /// <summary>
        /// 迭代法
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static ulong F1(int number)
        {
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return F1(number - 1) + F1(number - 2);
            }

        }
        #endregion

        #region 直接法
        /// <summary>
        /// 直接法
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static ulong F2(int number)
        {
            ulong a = 1, b = 1;
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                for (int i = 3; i <= number; i++)
                {
                    ulong c = a + b;
                    b = a;
                    a = c;
                }
                return a;
            }
        }
        #endregion


        #region 矩阵法
        /// <summary>
        /// 矩阵法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static ulong F3(int n)
        {
            ulong[,] a = new ulong[2, 2] { { 1, 1 }, { 1, 0 } };
            ulong[,] b = MatirxPower(a, n);
            return b[1, 0];
        }
        #endregion



        #region 通项公式法


        /// <summary>
        /// 通项公式法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static double F4(int n)
        {
            double sqrt5 = Math.Sqrt(5);
            return (1 / sqrt5 * (Math.Pow((1 + sqrt5) / 2, n) - Math.Pow((1 - sqrt5) / 2, n)));
        }
        #endregion




        #region 矩阵法
        static ulong[,] MatirxPower(ulong[,] a, int n)
        {
            if (n == 1) { return a; }
            else if (n == 2) { return MatirxMultiplication(a, a); }
            else if (n % 2 == 0)
            {
                ulong[,] temp = MatirxPower(a, n / 2);
                return MatirxMultiplication(temp, temp);
            }
            else
            {
                ulong[,] temp = MatirxPower(a, n / 2);
                return MatirxMultiplication(MatirxMultiplication(temp, temp), a);
            }
        }

        static ulong[,] MatirxMultiplication(ulong[,] a, ulong[,] b)
        {
            ulong[,] c = new ulong[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        #endregion




    }

}

