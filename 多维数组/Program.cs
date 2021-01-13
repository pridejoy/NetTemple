using System;

namespace 多维数组
{
    class Program
    {
        static void Main(string[] args)
        {
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
