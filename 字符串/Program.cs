using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace 字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = " Zhangsan ";

            //1.取字符串的长度，即字符串中字符的个数（算上空格）
            Console.WriteLine("字符串的个数为："+str.Length);
            //2.返回整数，得到指定的字符串在原字符串中第一次出现的位置
            Console.WriteLine("a在字符串中首次出现的位置是" + str.IndexOf("a"));
            //3.返回整数，得到指定的字符串在原字符串中最后一次出现的位置
            Console.WriteLine("a在字符串中最后一次出现的位置是" + str.LastIndexOf("a"));
            //4.返回布尔型的值，判断某个字符串是否以指定的字符串开头
            Console.WriteLine("字符串是否以Z开头" + str.StartsWith("Z"));
            //5.返回布尔型的值，判断某个字符串是否以指定的字符串结尾
            Console.WriteLine("字符串是否以Z结尾" + str.EndsWith("Z"));
            //6.返回一个新的字符串，将字符串中的大写字母转换成小写字母
            Console.WriteLine("字符串装换为小写字母" + str.ToLower());
            //7.返回一个新的字符串，将字符串中的小写字母转换成大写字母
            Console.WriteLine("字符串转换成大写" + str.ToUpper());
            //8.从当前字符串删除所有前导空白字符和尾随空白字符
            Console.WriteLine("从当前字符串删除所有前导空白字符和尾随空白字符" + str.Trim());
            //9.返回一个新的字符串，将字符串中指定位置的字符串移除
            Console.WriteLine("将字符串中指定位置的字符串移除" + str.Remove(2));
            //10.返回一个新的字符串，将字符串中左侧的空格删除
            Console.WriteLine("将字符串中左侧的空格删除" + str.TrimStart());
            //11.返回一个新的字符串，将字符串中右侧的空格删除
            Console.WriteLine("将字符串中右侧的空格删除" + str.TrimEnd());
            //12.返回一个新的字符串，从字符串的左侧填充空格达到指定的字符串长度
            Console.WriteLine("字符串的左侧填充空格达到指定的字符串长度" + str.PadLeft(5));
            //13.返回一个新的字符串，从字符串的右侧填充空格达到指定的字符串长度
            Console.WriteLine("字符串的右侧填充空格达到指定的字符串长度" + str.PadRight(2));
            //14.返回一个字符串类型的数组，根据指定的字符数组或者字符串数组中的字符 或字符串作为条件拆分字符串
            Console.WriteLine("字符串作为条件拆分字符串" + JsonConvert.SerializeObject(str.Split("a")));
            //15.返回一个新的字符串，用于将指定字符串替换给原字符串中指定的字符串
            Console.WriteLine("字符串替换给原字符串中指定的字符串" + str.Replace("z","B"));
            //16.返回一个新的字符串，用于截取指定的字符串
            Console.WriteLine("截取指定的字符串" + str.Substring(2));
            //17.返回一个新的字符串，将一个字符串插入到另一个字符串中指定索引的位置
            Console.WriteLine("字符串插入到另一个字符串中指定索引的位置" + str.Insert(2,"132"));
            //18.返回一个值，该值指示指定的子串是否出现在此字符串中
            Console.WriteLine("指定的子串是否出现在此字符串中"+ str.Contains("sa"));
            //19.字符串是否相等
            Console.WriteLine(str.Equals(" Zhangsan "));
            Console.WriteLine("转化为字符"+JsonConvert.SerializeObject(str.ToCharArray()));
            //ToBoolean 如果可能的话，把类型转换为布尔型。
            //ToByte 把类型转换为字节类型。
            //ToChar 如果可能的话，把类型转换为单个 Unicode 字符类型。
            //ToDateTime 把类型（整数或字符串类型）转换为 日期-时间 结构。
            //ToDecimal 把浮点型或整数类型转换为十进制类型。
            //ToDouble 把类型转换为双精度浮点型。
            //ToInt16 把类型转换为 16 位整数类型。
            //ToInt32 把类型转换为 32 位整数类型。
            //ToInt64 把类型转换为 64 位整数类型。
            //ToSbyte 把类型转换为有符号字节类型。
            //ToSingle 把类型转换为小浮点数类型。
            //ToString 把类型转换为字符串类型。
            //ToType 把类型转换为指定类型。
            //ToUInt16 把类型转换为 16 位无符号整数类型。
            //ToUInt32 把类型转换为 32 位无符号整数类型。
            //ToUInt64 把类型转换为 64 位无符号整数类型


            //Convert.ToInt16()   转换为整型(short)
            //Convert.ToInt32()   转换为整型(int)
            //Convert.ToInt64()   转换为整型(long)
            //Convert.ToChar()    转换为字符型(char)
            //Convert.ToString()  转换为字符串型(string)
            //Convert.ToDateTime()    转换为日期型(datetime)
            //Convert.ToDouble()  转换为双精度浮点型(double)
            //Conert.ToSingle()   转换为单精度浮点型(float)


            Console.WriteLine("请输入一个字符串：");
            string str2 = Console.ReadLine();
            string[] condition = { "," };
            string[] result = str2.Split(condition, StringSplitOptions.None);
            Console.WriteLine("字符串中含有逗号的个数为：" + (result.Length - 1));


            Console.WriteLine("请输入一个邮箱");
            string email = Console.ReadLine();
            Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
            if (regex.IsMatch(email))
            {
                Console.WriteLine("邮箱格式正确。");
            }
            else
            {
                Console.WriteLine("邮箱格式不正确。");
            }
        }
    }
}
