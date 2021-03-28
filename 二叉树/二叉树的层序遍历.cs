using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace 二叉树
{
     public  class 二叉树的层序遍历
    {
       

        public static void Do()
        {
            //[3,9,20,null,null,15,7],
            //给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）。
            var root1 = new TreeNode(3, new TreeNode(9), new TreeNode(2,new TreeNode(15),new  TreeNode(7))) { };

            var a = PreorderTraversal(root1);


            Console.WriteLine(JsonConvert.SerializeObject(a));
        }


        public static IList<IList<int>> ints = new List<IList<int>>();
        public  static Queue<TreeNode> queue = new  Queue<TreeNode>();
        public static IList<IList<int>> PreorderTraversal(TreeNode root)
        {
            IList<int> ints2 = new List<int>();
            if (root != null)
            {
                if (root.val != 0)
                {
                    ints2.Add(root.val);
                    if (root.left!=null)
                        PreorderTraversal(root.left);
                    if (root.right != null)
                        PreorderTraversal(root.right);
                }

                ints.Add(ints2);
                
            }
            return ints;
        }
    }


}
