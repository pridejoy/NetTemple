using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.基础
{
    /// <summary>
    /// 数组和字符串
    /// </summary>
    public class 寻找数组的中心索引
    {

        public static void DoSmaple()
        {
            #region 题目


            //给你一个整数数组 nums，请编写一个能够返回数组 “中心下标” 的方法。
            //数组 中心下标 是数组的一个下标，其左侧所有元素相加的和等于右侧所有元素相加的和。
            //如果数组不存在中心下标，返回 - 1 。如果数组有多个中心下标，应该返回最靠近左边的那一个。
            //注意：中心下标可能出现在数组的两端。



            //示例 1：

            //输入：nums = [1, 7, 3, 6, 5, 6]
            //输出：3
            //解释：
            //中心下标是 3 。
            //左侧数之和(1 + 7 + 3 = 11)，
            //右侧数之和(5 + 6 = 11) ，二者相等。
            //示例 2：

            var nums1 = new[] {1, 7, 3, 6, 5, 6};
            PivotIndex(nums1);


            //输入：nums = [1, 2, 3]
            //输出：-1
            //解释：
            //数组中不存在满足此条件的中心下标。
            //示例 3：

            //输入：nums = [2, 1, -1]
            //输出：0
            //解释：
            //中心下标是 0 。
            //下标 0 左侧不存在元素，视作和为 0 ；
            //右侧数之和为 1 + (-1) = 0 ，二者相等。


            //提示：

            //nums 的长度范围为[0, 10000]。
            //任何一个 nums[i] 将会是一个范围在[-1000, 1000]的整数。

            //作者：力扣(LeetCode)
            //链接：https://leetcode-cn.com/leetbook/read/array-and-string/yf47s/
            //来源：力扣（LeetCode）
            //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

            #endregion

        }

        public static int PivotIndex(int[] nums)
        {
            var num = nums.ToList();
            num.Sort();
            var a = num.Count / 2;
            for (int i = a; i < num.Count; i++)
            {

            }

            return 1;
        }
    }

    public class 搜索插入位置
    {

        public static void DoSmaple()
        {
            #region 题目

            //给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
            //你可以假设数组中无重复元素。

            //示例 1:
            //输入:[1,3,5,6], 5
            //输出: 2


            //示例 2:
            //输入:[1,3,5,6], 2
            //输出: 1


            //示例 3:
            //输入:[1,3,5,6], 7
            //输出: 4


            //示例 4:
            //输入:[1,3,5,6], 0
            //输出: 0
            int[] nums1 = new[] {1, 3, 5, 6};
            int target1 = 7;
            var result1 = SearchInsert(nums1, target1);

            //作者：力扣(LeetCode)
            //链接：https://leetcode-cn.com/leetbook/read/array-and-string/cxqdh/
            //来源：力扣（LeetCode）
            //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

            #endregion

            Console.WriteLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            #region 解法一

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i]==target)
            //    {
            //        return i;
            //    }
            //}
            ////不存在返回
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] > target)
            //    {
            //        return i;
            //    }
            //}
            //return nums.Length;

            #region 解法二

            int a = nums.Length;
            for (int i = 0; i < a; i++)
            {
                if (nums[i] == target)
                {
                    return i;

                }
                else if (target < nums[i])
                {
                    a = i;
                    return a;
                }
            }

            return a;

            #endregion

            #endregion
        }
    }

    public class 合并区间
    {

        public static void DoSmaple()
        {
            #region 题目
            //以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。

            //示例 1：
            //输入：intervals = [[1, 3],[2,6],[8,10],[15,18]]
            //输出：[[1,6],[8,10],[15,18]]
            //解释：区间[1, 3] 和[2, 6] 重叠, 将它们合并为[1, 6].

            //int [][2] intervals = { {1,3},{2,6},{8,10},{15,18}};
            //var aa = Merge(intervals);
            //示例 2：
            //输入：intervals = [[1, 4],[4,5]]
            //输出：[[1,5]]
            //解释：区间[1, 4] 和[4, 5] 可被视为重叠区间。

            //作者：力扣(LeetCode)
            //链接：https://leetcode-cn.com/leetbook/read/array-and-string/c5tv3/
            //来源：力扣（LeetCode）
            //著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

            #endregion

        }

        //public static int[][] Merge(int[][] intervals)
        //{
        //    return new [][]{new []{1,2},new []{2,3}}；
        //}


    }

    public class 搜索插入位置2
    {

        public static void DoSmaple()
        {
            #region 题目

            #endregion

        }

        public static int SearchInsert(int[] nums, int target)
        {
            return 0;
        }



    }
}
