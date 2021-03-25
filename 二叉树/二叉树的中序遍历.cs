using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace 二叉树
{
    public class 二叉树的中序遍历
    {
        //中序遍历是先遍历左子树，然后访问根节点，然后遍历右子树。
        public static void DO()
        {




            //1.
            //输入：root = [1, null, 2, 3]
            //输出：[1,3,2]
            //先定义
            var root=new TreeNode(1,null,new  TreeNode(2,new TreeNode(3),null));


            //2.
            //输入：root = []
            //输出：[]
            var root1=new TreeNode();


            //3.
            //输入：root = [1]
            //输出：[1]
            var root3 = new TreeNode(1);

            //4.
            //输入：root = [1, null, 2]
            //输出：[1,2]
            //var root4 = new TreeNode(1,new TreeNode(),new TreeNode(2) );
            var root4 = new TreeNode(1,null,new TreeNode(2) );

            var a = PreorderTraversal(root4);
            

            Console.WriteLine(JsonConvert.SerializeObject(a));


        }

        public static IList<int> ints2 = new List<int>();
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            //中序遍历是先遍历左子树，然后访问根节点，然后遍历右子树。
            //解题思路：先判断左侧，如果没有的话，就添加跟接点，再看右子树
            if (root != null|| root.val!=0)
            {
                if (root.left != null)
                    PreorderTraversal(root.left);
                ints2.Add(root.val);
                if (root.right != null)
                    PreorderTraversal(root.right);
            }
            return ints2;
        }


    }
}
