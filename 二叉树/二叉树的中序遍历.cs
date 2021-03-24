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

            var a = PreorderTraversal(root);
            

            Console.WriteLine(JsonConvert.SerializeObject(a));


        }

        public static IList<int> ints2 = new List<int>();
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                if (root.left == null)
                    ints2.Add(root.val);
                if (root.right == null)
                    ints2.Add(root.val);
                if (root.right != null)
                {
                    PreorderTraversal(root.right);
                }

                
            }
            return ints2;
        }


    }
}
