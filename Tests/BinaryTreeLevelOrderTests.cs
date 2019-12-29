using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class BinaryTreeLevelOrderTests
    {
        [Fact]
        public void IterativeTestWithEmptyTree()
        {
            BinaryTreeLevelOrderTraversal.TreeNode root = null;
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal.IterativeLevelOrder(root);
            Assert.Equal(0, levelorder.Count);
        }

        [Fact]
        public void IterativeTestWithThreeLevels()
        {
            // Arrange
            BinaryTreeLevelOrderTraversal.TreeNode root = new BinaryTreeLevelOrderTraversal.TreeNode(3);
            root.left = new BinaryTreeLevelOrderTraversal.TreeNode(5);
            root.right = new BinaryTreeLevelOrderTraversal.TreeNode(9);
            root.right.left = new BinaryTreeLevelOrderTraversal.TreeNode(17);
            root.right.right = new BinaryTreeLevelOrderTraversal.TreeNode(20);
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal.IterativeLevelOrder(root);
            IList<IList<int>> expectList = new List<IList<int>>();
            for (int i = 0; i < 3; i++)
            {
                expectList.Add(new List<int>());
            }
            expectList[0].Add(3);
            expectList[1].Add(5);
            expectList[1].Add(9);
            expectList[2].Add(17);
            expectList[2].Add(20);

            // Assert
            int index = 0;
            Console.WriteLine("Iterative Level Order: ");
            foreach (IList<int> level in levelorder)
            {
                for (int i = 0; i < level.Count; i++)
                {
                    int val = level[i];
                    Assert.Equal(val, expectList[index][i]);
                    Console.Write(val + " ");
                }
                index++;
                Console.WriteLine();
            }
        }

        [Fact]
        public void RecursiveTestWithEmptyTree()
        {
            BinaryTreeLevelOrderTraversal.TreeNode root = null;
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal.RecursiveLevelOrder(root);
            Assert.Equal(0, levelorder.Count);
        }

        [Fact]
        public void RecursiveTestWithThreeLevels()
        {
            // Arrange
            BinaryTreeLevelOrderTraversal.TreeNode root = new BinaryTreeLevelOrderTraversal.TreeNode(3);
            root.left = new BinaryTreeLevelOrderTraversal.TreeNode(5);
            root.right = new BinaryTreeLevelOrderTraversal.TreeNode(9);
            root.right.left = new BinaryTreeLevelOrderTraversal.TreeNode(17);
            root.right.right = new BinaryTreeLevelOrderTraversal.TreeNode(20);
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal.RecursiveLevelOrder(root);
            IList<IList<int>> expectList = new List<IList<int>>();
            for (int i = 0; i < 3; i++)
            {
                expectList.Add(new List<int>());
            }
            expectList[0].Add(3);
            expectList[1].Add(5);
            expectList[1].Add(9);
            expectList[2].Add(17);
            expectList[2].Add(20);

            // Assert
            int index = 0;
            Console.WriteLine("Recursive Level Order: ");
            foreach (IList<int> level in levelorder)
            {
                for (int i = 0; i < level.Count; i++)
                {
                    int val = level[i];
                    Assert.Equal(val, expectList[index][i]);
                    Console.Write(val + " ");
                }
                index++;
                Console.WriteLine();
            }
        }
    }
}
