using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class MergeSortTests
    {
        public static readonly int[] expectInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public static readonly char[] expectChar = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n' };

        [Fact]
        public void IntTopdownTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };

            MergeSort<int>.TopDownSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], expectInt[i]);
            }
        }

        [Fact]
        public void StringTopdownTest()
        {
            char[] array = { 'm', 'n', 'a', 'k', 'c', 'd', 'g', 'j', 'b', 'l', 'f', 'i', 'e', 'h' };

            MergeSort<char>.TopDownSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], expectChar[i]);
            }
        }

        [Fact]
        public void IntBottomupTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };

            MergeSort<int>.BottomUpSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], expectInt[i]);
            }
        }

        [Fact]
        public void StringBottomupTest()
        {
            char[] array = { 'm', 'n', 'a', 'k', 'c', 'd', 'g', 'j', 'b', 'l', 'f', 'i', 'e', 'h' };

            MergeSort<char>.BottomUpSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i], expectChar[i]);
            }
        }
    }
}
