using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace 二叉树
{
    public class 二叉树的后序遍历
    {
        //后序遍历
        // 后序遍历是先遍历左子树，然后遍历右子树，最后访问树的根节点

        public static void Do()
        {
            //1.
            //输入：root = [1, null, 2, 3]
            //输出：[1,3,2]
            var root =new TreeNode(1,null,new TreeNode(2,new TreeNode(3),null));


            //2.
            //输入：root = []
            //输出：[]
            var root2=new TreeNode();

            //3.
            //输入：root = [1]
            //输出：[1]
            var root3 = new TreeNode(1);

            //4.
            //输入：root = [1, 2]
            //输出：[2,1]
            var root4 = new TreeNode(1,new TreeNode(2),null);


            //5.
            //输入：root = [1, null, 2]
            //输出：[1,2]
            var root5 = new TreeNode(1, null, new TreeNode(2));


            var a = PreorderTraversal(root5);


            Console.WriteLine(JsonConvert.SerializeObject(a));
        }

        
        public static IList<int> ints2 = new List<int>();
        /// <summary>
        /// 解题思路-》连遍历左子树，有的话在遍历左子树，没有的话，先遍历右节点（有的话从头开始），最后添加根节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                if (root.left != null)
                    PreorderTraversal(root.left);
                if (root.right != null)
                    PreorderTraversal(root.right);
                if (root.val != 0)
                    ints2.Add(root.val);
            }
            return ints2;
        }

    }
}
