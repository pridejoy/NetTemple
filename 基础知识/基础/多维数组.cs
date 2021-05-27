using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.基础
{
    public  class 多维数组
    {
        public static void DoSmaple()
        {
            //1   Clear() 清空数组中的元素
            //2   Sort()  冒泡排序，从小到大排序数组中的元素
            //3   Reverse()   将数组中的元素逆序排列
            //4   IndexOf()   查找数组中是否含有某个元素，返回该元素第一次出现的位置，如果没有与之匹配的元素，则返回 - 1
            //5   LastIndexOf()   查找数组中是否含有某个元素，返回该元素最后一次出现的位置


            int[] a = { 5, 1, 7, 2, 3, 0, -1, -9 };
            //相当于冒泡排序
            Array.Sort(a);
            Console.WriteLine("排序后的结果为：");
            foreach (int b in a)
            {
                Console.Write(b + " ");
            }


            //创建多维数组并初始化
            //数据类型[ , , ...]   数组名 = new 数据类型[m, n, ...] { { , , ...}, { , , ...} };

            double[,] points = { { 90, 80 }, { 100, 89 }, { 88.5, 86 } };
            for (int i = 0; i < points.GetLength(0); i++)
            {
                Console.WriteLine("第" + (i + 1) + "个学生成绩：");
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    Console.Write(points[i, j] + " ");
                }
                Console.WriteLine();
            }


            //锯齿型数组
            //数据类型[][] 数组名 = new 数据类型[数组长度][];
            //数组名[0] = new 数据类型[数组长度];
            int[][] arrays = new int[3][];
            arrays[0] = new int[] { 1, 2 };
            arrays[1] = new int[] { 3, 4, 5 };
            arrays[2] = new int[] { 6, 7, 8, 9 };
            for (int i = 0; i < arrays.Length; i++)
            {
                Console.WriteLine("输出数组中第" + (i + 1) + "行的元素：");
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
