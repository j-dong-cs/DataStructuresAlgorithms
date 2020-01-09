using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class BinaryTreeLevelOrderTests
    {
        [Fact]
        public void ConstructBSTfromLevelOrder()
        {
            // arrange
            char[] array = { 'S', 'E', 'T', 'A', 'R', 'C', 'H', 'M' };
            BinaryTreeLevelOrderTraversal<char>.TreeNode root = BinaryTreeLevelOrderTraversal<char>.ReconstructFromLevelOrder(array);
            IList<IList<char>> expectChars = new List<IList<char>>();
            for (int i = 0; i < 5; i++)
            {
                expectChars.Add(new List<char>());
            }
            expectChars[0].Add('S');
            expectChars[1].Add('E');
            expectChars[1].Add('T');
            expectChars[2].Add('A');
            expectChars[2].Add('R');
            expectChars[3].Add('C');
            expectChars[3].Add('H');
            expectChars[4].Add('M');

            // assert
            int index = 0;
            Console.WriteLine("Reconstruct tree from Level Order: ");
            foreach (IList<char> level in expectChars)
            {
                for (int i = 0; i < level.Count; i++)
                {
                    char val = level[i];
                    Assert.Equal(val, expectChars[index][i]);
                    Console.Write(val + " ");
                }
                index++;
                Console.WriteLine();
            }
        }

        [Fact]
        public void IterativeTestWithEmptyTree()
        {
            BinaryTreeLevelOrderTraversal<int>.TreeNode root = null;
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal<int>.IterativeLevelOrder(root);
            Assert.Equal(0, levelorder.Count);
        }

        [Fact]
        public void IterativeTestWithThreeLevels()
        {
            // Arrange
            BinaryTreeLevelOrderTraversal<int>.TreeNode root = new BinaryTreeLevelOrderTraversal<int>.TreeNode(3);
            root.left = new BinaryTreeLevelOrderTraversal<int>.TreeNode(5);
            root.right = new BinaryTreeLevelOrderTraversal<int>.TreeNode(9);
            root.right.left = new BinaryTreeLevelOrderTraversal<int>.TreeNode(17);
            root.right.right = new BinaryTreeLevelOrderTraversal<int>.TreeNode(20);
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal<int>.IterativeLevelOrder(root);
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
            BinaryTreeLevelOrderTraversal<int>.TreeNode root = null;
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal<int>.RecursiveLevelOrder(root);
            Assert.Equal(0, levelorder.Count);
        }

        [Fact]
        public void RecursiveTestWithThreeLevels()
        {
            // Arrange
            BinaryTreeLevelOrderTraversal<int>.TreeNode root = new BinaryTreeLevelOrderTraversal<int>.TreeNode(3);
            root.left = new BinaryTreeLevelOrderTraversal<int>.TreeNode(5);
            root.right = new BinaryTreeLevelOrderTraversal<int>.TreeNode(9);
            root.right.left = new BinaryTreeLevelOrderTraversal<int>.TreeNode(17);
            root.right.right = new BinaryTreeLevelOrderTraversal<int>.TreeNode(20);
            IList<IList<int>> levelorder = BinaryTreeLevelOrderTraversal<int>.RecursiveLevelOrder(root);
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
