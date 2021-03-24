using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace 二叉树
{
    public class 二叉树的前序遍历
    {

        //执行的方法
        //前序遍历首先访问根节点，然后遍历左子树，最后遍历右子树
        public static void DO()
        {
            #region 二叉树的前序遍历
            var root1 = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null)) { };
            //定义一个二叉树

            //1.
            //root = [1, null, 2, 3]
            //输出：[1,2,3]

            //2.
            //输入：root = []
            //输出：[]
            var root2 = new TreeNode();

            //3.
            //输入：root = [1]
            //输出：[1]
            var root3 = new TreeNode(1);

            //4.
            //输入：root = [1, 2]
            //输出：[1,2]
            var root4 = new TreeNode(1, new TreeNode(2));

            //5.
            //输入：root = [1, null, 2]
            //输出：[1,2]
            var root5 = new TreeNode(1, null, new TreeNode(2));
            //二叉树的前序遍历
            //前序遍历首先访问根节点，然后遍历左子树，最后遍历右子树。
            //理解：先便利根节点，在遍历左节点，在遍历右键点
            var a = PreorderTraversal(root5);
            #endregion


            Console.WriteLine(JsonConvert.SerializeObject(a));
        }


        public static IList<int> ints2 = new List<int>();
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                if (root.val != 0)
                    ints2.Add(root.val);
                if (root.left != null)
                    PreorderTraversal(root.left);
                if (root.right != null)
                    PreorderTraversal(root.right);
            }
            return ints2;
        }
    }
}
