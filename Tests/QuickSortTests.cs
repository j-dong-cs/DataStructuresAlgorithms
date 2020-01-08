using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class QuickSortTests
    {
        public static readonly int[] expectInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public static readonly string[] expectName = { "abbey", "alex", "alice", "ben", "benny", "bobby", "cate", "john", "johnny", "luis", "shawn", "shirley", "zoe" };
        public static readonly char[] expectDup = { 'a', 'a', 'a', 'b', 'b', 'c', 'c', 'c', 'c', 'e', 'e', 'x', 'x', 'y', 'z' };

        [Fact]
        public void ThreeWaySort()
        {
            char[] array = { 'c', 'e', 'c', 'a', 'b', 'x', 'a', 'c', 'z', 'a', 'b', 'c', 'e', 'x', 'y' };
            QuickSort<char>.ThreeWaySort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectDup[i], array[i]);
            }
        }

        [Fact]
        public void QuickSelectAscendingTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };
            for (int i = 0; i < array.Length; i++)
            {
                int val = QuickSort<int>.QuickSelectAscending(array, i);
                Assert.Equal(expectInt[i], val);
            }
        }

        [Fact]
        public void QuickSelectDescendingTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };
            for (int i = 0; i < array.Length; i++)
            {
                int val = QuickSort<int>.QuickSelectDescending(array, i);
                Assert.Equal(expectInt[expectInt.Length - 1 - i], val);
            }
        }

        [Fact]
        public void Median3SortIntTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };

            QuickSort<int>.Median3Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectInt[i], array[i]);
            }
        }

        [Fact]
        public void Median3SortStrTest()
        {
            string[] array = { "zoe", "alex", "luis", "ben", "johnny", "benny", "abbey", "shawn", "alice", "shirley", "john", "bobby", "cate" };
            QuickSort<string>.Median3Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectName[i], array[i]);
            }
        }

        [Fact]
        public void ThreeWayRadixSortTest()
        {
            string[] array = { "zoe", "alex", "luis", "ben", "johnny", "benny", "abbey", "shawn", "alice", "shirley", "john", "bobby", "cate" };
            QuickSort<string>.ThreeWayRadixSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectName[i], array[i]);
            }
        }
    }
}
