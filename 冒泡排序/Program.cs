using System;

namespace 冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {


			//冒泡排序
			//它重复地走访过要排序的元素列，依次比较两个相邻的元素，
			//如果顺序（如从大到小、首字母从Z到A）错误就把他们交换过来。
			//走访元素的工作是重复地进行直到没有相邻元素需要交换，也就是说该元素列已经排序完成。


			//这个算法的名字由来是因为越小的元素会经由交换慢慢“浮”到数列的顶端（升序或降序排列），
			//就如同碳酸饮料中二氧化碳的气泡最终会上浮到顶端一样，故名“冒泡排序”。


			int[] intArr = new int[] { 10, 8, 3, 5, 6, 7, 9 };
			Console.Write("排序前：");
			for (int i = 0; i < intArr.Length; i++)
			{
				Console.Write(intArr[i] + " ");
			}
			Console.WriteLine();

			BubbleSort(ref intArr);

			Console.Write("排序后：");
			for (int i = 0; i < intArr.Length; i++)
			{
				Console.Write(intArr[i] + " ");
			}
			Console.WriteLine();

			Console.WriteLine("计算次数：" + calCount);

			Console.ReadLine();
		}

		static int calCount = 0;
		/// <summary>
		/// 冒泡排序
		/// </summary>
		/// <param name="data"></param>
		public static void BubbleSort(ref int[] data)
		{
			for (int i = 0; i < data.Length - 1; i++)
			{
				for (int j = data.Length - 1; j > i; j--)
				{
					calCount++;
					if (data[j] > data[j - 1])
					{
						data[j] = data[j] + data[j - 1];
						data[j - 1] = data[j] - data[j - 1];
						data[j] = data[j] - data[j - 1];
					}
				}
			}
		}
	}
}
