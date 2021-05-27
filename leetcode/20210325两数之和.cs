using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace leetcode
{
    public class _20210325两数之和
    {
        public static void DoSmaple()
        {

            //使用方法-把下面的注释解开

            #region 2021-03-25  1. 两数之和  

            //https://leetcode-cn.com/problems/two-sum/
            //给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 的那 两个 整数，并返回它们的数组下标。
            //你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
            //你可以按任意顺序返回答案。

            //示例 1：
            //输入：nums = [2, 7, 11, 15], target = 9
            //输出：[0,1]
            //解释：因为 nums[0] +nums[1] == 9 ，返回[0, 1] 。
            int[] nums1 = new int[] { 2, 7, 11, 15 };
            int target1 = 9;




            //示例 2：
            //输入：nums = [3, 2, 4], target = 6
            //输出：[1,2]
            int[] nums2 = new int[] { 3, 2, 4 };
            int target2 = 6;

            //示例 3：
            //输入：nums = [3, 3], target = 6
            //输出：[0,1]
            int[] nums3 = new int[] { 3, 3 };
            int target3 = 6;

            var A = One_TwoSum(nums2, target2);
            Console.WriteLine(JsonConvert.SerializeObject(A));
            //1.两数之和
            int[] One_TwoSum(int[] nums, int target)
            {
                int[] marks = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    var num = nums[i];
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            marks[0] = i;
                            marks[1] = j;
                        }
                    }
                }
                return marks;
            }




            #endregion
        }
    }
}
