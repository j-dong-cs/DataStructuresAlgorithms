using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public static class BinaryTreeLevelOrderTraversal
    {

        public static IList<IList<int>> IterativeLevelOrder(TreeNode root)
        {
            IList<IList<int>> levels = new List<IList<int>>();
            if (root == null) return levels;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int level = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                levels.Add(new List<int>());
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    levels[level].Add(cur.val);

                    if (cur.left != null) queue.Enqueue(cur.left);
                    if (cur.right != null) queue.Enqueue(cur.right);
                }

                level++;
            }

            return levels;
        }

        public static IList<IList<int>> RecursiveLevelOrder(TreeNode root)
        {
            IList<IList<int>> levels = new List<IList<int>>();
            if (root == null) return levels;
            RecursiveLevelOrderHelper(levels, root, 0);
            return levels;
        }

        private static void RecursiveLevelOrderHelper(IList<IList<int>> levels, TreeNode root, int level)
        {
            if (levels.Count < level + 1) levels.Add(new List<int>());
            levels[level].Add(root.val);

            if (root.left != null) RecursiveLevelOrderHelper(levels, root.left, level + 1);
            if (root.right != null) RecursiveLevelOrderHelper(levels, root.right, level + 1);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val)
            {
                this.val = val;
                this.left = null;
                this.right = null;
            }
        }
    }
}
