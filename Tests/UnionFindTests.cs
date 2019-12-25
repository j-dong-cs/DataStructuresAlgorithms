using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class UnionFindTests
    {
        public static int n = 10;

        [Fact]
        public void WeightedQuickUnionPathCompressionTest()
        {
            WeightedQuickUnionPathCompressionUF uf = new WeightedQuickUnionPathCompressionUF(n);
            uf.Union(3, 4);
            int[] expected = { 0, 1, 2, 3, 3, 5, 6, 7, 8, 9 };
            Console.WriteLine("Merge 3 and 4: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 1);

            Console.WriteLine("Merge 4 and 9: ");
            expected = new int[] { 0, 1, 2, 3, 3, 5, 6, 7, 8, 3 };
            uf.Union(4, 9);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 2);

            Console.WriteLine("Merge 8 and 0: ");
            expected = new int[] { 8, 1, 2, 3, 3, 5, 6, 7, 8, 3 };
            uf.Union(8, 0);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 3);

            Console.WriteLine("Merge 2 and 3: ");
            expected = new int[] { 8, 1, 3, 3, 3, 5, 6, 7, 8, 3 };
            uf.Union(2, 3);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 4);

            Console.WriteLine("Merge 5 and 6: ");
            expected = new int[] { 8, 1, 3, 3, 3, 5, 5, 7, 8, 3 };
            uf.Union(5, 6);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 5);

            Console.WriteLine("Merge 5 and 9: ");
            expected = new int[] { 8, 1, 3, 3, 3, 3, 5, 7, 8, 3 };
            uf.Union(5, 9);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 6);

            Console.WriteLine("Merge 7 and 3: ");
            expected = new int[] { 8, 1, 3, 3, 3, 3, 5, 3, 8, 3 };
            uf.Union(7, 3);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 7);

            Console.WriteLine("Merge 4 and 8: ");
            expected = new int[] { 8, 1, 3, 3, 3, 3, 5, 3, 3, 3 };
            uf.Union(4, 8);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 8);

            Console.WriteLine("Merge 6 and 1: ");
            expected = new int[] { 8, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            uf.Union(6, 1);
            for (int i = 0; i < n; i++)
            {
                Console.Write(uf.Parent[i] + " ");
                Assert.Equal(uf.Parent[i], expected[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Number of components: {uf.NumComponents}");
            Assert.Equal(uf.NumComponents, n - 9);
        }
    }
}
