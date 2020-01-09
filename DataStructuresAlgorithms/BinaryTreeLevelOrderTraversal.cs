using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public static class BinaryTreeLevelOrderTraversal<T> where T : IComparable<T>
    {
        public static TreeNode ReconstructFromLevelOrder(T[] array)
        {
            if (array == null || array.Length == 0) return null;
            TreeNode root = null;
            for (int i = 0; i < array.Length; i++)
            {
                LeverOrderBuildHelper(root, array[i]);
            }
            return root;
        }

        private static TreeNode LeverOrderBuildHelper(TreeNode root, T val)
        {
            // insert new node
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (val.CompareTo(root.val) <= 0) // add to left child if smaller
            {
                root.left = LeverOrderBuildHelper(root.left, val);
            }
            else
            {
                root.right = LeverOrderBuildHelper(root.right, val);
            }

            return root;
        }

        public static IList<IList<T>> IterativeLevelOrder(TreeNode root)
        {
            IList<IList<T>> levels = new List<IList<T>>();
            if (root == null) return levels;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int level = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                levels.Add(new List<T>());
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

        public static IList<IList<T>> RecursiveLevelOrder(TreeNode root)
        {
            IList<IList<T>> levels = new List<IList<T>>();
            if (root == null) return levels;
            RecursiveLevelOrderHelper(levels, root, 0);
            return levels;
        }

        private static void RecursiveLevelOrderHelper(IList<IList<T>> levels, TreeNode root, int level)
        {
            if (levels.Count < level + 1) levels.Add(new List<T>());
            levels[level].Add(root.val);

            if (root.left != null) RecursiveLevelOrderHelper(levels, root.left, level + 1);
            if (root.right != null) RecursiveLevelOrderHelper(levels, root.right, level + 1);
        }

        public class TreeNode
        {
            public T val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(T val)
            {
                this.val = val;
                this.left = null;
                this.right = null;
            }
        }
    }
}
