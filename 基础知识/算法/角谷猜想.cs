using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础知识.算法
{
     public  class 角谷猜想
    {
        public static void DoSmaple()
        {

            //定义
            //任何一个大于一的自然数，如果是奇数，则乘以三再加一；
            //如果是偶数，则除以二；得出的结果继续按照前面的规则进行运算，最后必定得到一。 
            //该猜想由日本数学家角谷静夫发现，又被称为考拉兹猜想，
            //3n+1猜想、哈塞猜想、乌拉姆猜想或叙拉古猜想。


            Console.WriteLine("请输入一个大于1的正整数!");
            string aStrInput = Console.ReadLine();
            int aIntInput;
            bool aAgain = true;
            while (aAgain)
            {
                while (!int.TryParse(aStrInput, out aIntInput) || aIntInput <= 1)
                {
                    Console.WriteLine("请输入一个大于1的正整数!");
                    aStrInput = Console.ReadLine();
                }
                int aIntOutput = aIntInput;
                while (aIntOutput != 1)
                {
                    if (aIntOutput % 2 == 0)
                    {
                        aIntOutput /= 2;
                    }
                    else
                    {
                        aIntOutput = aIntOutput * 3 + 1;
                    }
                    Console.WriteLine(aIntOutput.ToString());
                }
                Console.WriteLine("按数字0退出系统，按数字1重试");
                aStrInput = Console.ReadLine();
                while (!int.TryParse(aStrInput, out aIntInput) || (aIntInput != 0 && aIntInput != 1))
                {
                    Console.WriteLine("请输入正确的命令!");
                    aStrInput = Console.ReadLine();
                }
                aAgain = aIntInput == 0 ? false : true;
            }

        }

	}

}

