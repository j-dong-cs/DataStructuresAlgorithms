using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public class BinaryTreeIterativeTraversal
    {
        // This method iteratively traverse the binray tree in preorder.
        public static List<int> PreorderIterativeTraverse(TreeNode root)
        {
            List<int> preorder = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }

            while (stack.Count > 0)
            {
                // Pop TreeNode in the stack and add to the preorder list
                TreeNode node = stack.Pop();
                preorder.Add(node.val);

                // Push node's children into stack; right first then left
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }

            return preorder;
        }

        // This method iteratively traverse the binray tree in inorder.
        public static List<int> InorderIterativeTraverse(TreeNode root)
        {
            List<int> inorder = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            // Push all the left children into stack
            TreeNode cur = root;
            while (stack.Count > 0 || cur != null)
            {
                // push all the left children
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                // pop root
                cur = stack.Pop();
                inorder.Add(cur.val);
                // go to right child
                cur = cur.right;
            }

            return inorder;
        }

        // This method iteratively traverse the binray tree in postorder.
        public static List<int> PostorderIterativeTraverse(TreeNode root)
        {
            List<int> postorder = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode cur = root;
            TreeNode lastNodeVisited = null;
            while (stack.Count > 0 || cur != null)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                TreeNode peekNode = stack.Peek();
                if (peekNode.right != null && lastNodeVisited != peekNode.right)
                {
                    cur = peekNode.right;
                }
                else
                {
                    postorder.Add(peekNode.val);
                    lastNodeVisited = stack.Pop();
                }

            }
            return postorder;
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
