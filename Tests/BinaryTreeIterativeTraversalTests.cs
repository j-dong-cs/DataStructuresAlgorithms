using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class BinaryTreeIterativeTraversalTests
    {
        BinaryTreeIterativeTraversal.TreeNode root;
        List<int> expectedList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Fact]
        public void PreorderIterativeTest()
        {
            // Test Empty tree
            root = null;
            Assert.Equal<List<int>>(new List<int>(), BinaryTreeIterativeTraversal.PreorderIterativeTraverse(root));

            // 1. Arrange
            // Build up a binary tree
            //           1
            //        /     \
            //       2       6
            //      /  \    /  \
            //     3    5  7    10
            //    /       /
            //   4       8
            //            \
            //             9
            root = new BinaryTreeIterativeTraversal.TreeNode(1);
            root.left = new BinaryTreeIterativeTraversal.TreeNode(2);
            root.right = new BinaryTreeIterativeTraversal.TreeNode(6);
            root.left.left = new BinaryTreeIterativeTraversal.TreeNode(3);
            root.left.right = new BinaryTreeIterativeTraversal.TreeNode(5);
            root.right.left = new BinaryTreeIterativeTraversal.TreeNode(7);
            root.right.right = new BinaryTreeIterativeTraversal.TreeNode(10);
            root.right.left.left = new BinaryTreeIterativeTraversal.TreeNode(8);
            root.right.left.left.right = new BinaryTreeIterativeTraversal.TreeNode(9);
            root.left.left.left = new BinaryTreeIterativeTraversal.TreeNode(4);

            // 2. Assert
            List<int> preorder = BinaryTreeIterativeTraversal.PreorderIterativeTraverse(root);
            for (int i = 0; i < preorder.Count; i++)
            {
                Assert.Equal(expectedList[i], preorder[i]);
            }
        }

        [Fact]
        public void InorderIterativeTest()
        {
            // Test Empty tree
            root = null;
            Assert.Equal<List<int>>(new List<int>(), BinaryTreeIterativeTraversal.InorderIterativeTraverse(root));

            //           5
            //        /     \
            //       3       9
            //      /  \    /  \
            //     2    4  8    10
            //    /       /
            //   1       6
            //            \
            //             7
            root = new BinaryTreeIterativeTraversal.TreeNode(5);
            root.left = new BinaryTreeIterativeTraversal.TreeNode(3);
            root.right = new BinaryTreeIterativeTraversal.TreeNode(9);
            root.left.left = new BinaryTreeIterativeTraversal.TreeNode(2);
            root.left.right = new BinaryTreeIterativeTraversal.TreeNode(4);
            root.right.left = new BinaryTreeIterativeTraversal.TreeNode(8);
            root.right.right = new BinaryTreeIterativeTraversal.TreeNode(10);
            root.left.left.left = new BinaryTreeIterativeTraversal.TreeNode(1);
            root.right.left.left = new BinaryTreeIterativeTraversal.TreeNode(6);
            root.right.left.left.right = new BinaryTreeIterativeTraversal.TreeNode(7);

            List<int> inorder = BinaryTreeIterativeTraversal.InorderIterativeTraverse(root);
            for (int i = 0; i < inorder.Count; i++)
            {
                Assert.Equal(expectedList[i], inorder[i]);
            }
        }

        [Fact]
        public void PostorderIterativeTest()
        {
            // Test Empty tree
            root = null;
            Assert.Equal<List<int>>(new List<int>(), BinaryTreeIterativeTraversal.PostorderIterativeTraverse(root));

            //           10
            //        /     \
            //       4       9
            //      /  \    /  \
            //     2    3  7    8
            //    /       /
            //   1       6
            //            \
            //             5
            root = new BinaryTreeIterativeTraversal.TreeNode(10);
            root.left = new BinaryTreeIterativeTraversal.TreeNode(4);
            root.right = new BinaryTreeIterativeTraversal.TreeNode(9);
            root.left.left = new BinaryTreeIterativeTraversal.TreeNode(2);
            root.left.right = new BinaryTreeIterativeTraversal.TreeNode(3);
            root.right.left = new BinaryTreeIterativeTraversal.TreeNode(7);
            root.right.right = new BinaryTreeIterativeTraversal.TreeNode(8);
            root.left.left.left = new BinaryTreeIterativeTraversal.TreeNode(1);
            root.right.left.left = new BinaryTreeIterativeTraversal.TreeNode(6);
            root.right.left.left.right = new BinaryTreeIterativeTraversal.TreeNode(5);

            List<int> postorder = BinaryTreeIterativeTraversal.PostorderIterativeTraverse(root);
            for (int i = 0; i < postorder.Count; i++)
            {
                Assert.Equal(expectedList[i], postorder[i]);
            }
        }
    }
}
