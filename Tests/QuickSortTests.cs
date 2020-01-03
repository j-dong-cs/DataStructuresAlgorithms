using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class QuickSortTests
    {
        public static readonly int[] expectInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public static readonly string[] expectStr = { "alice", "ben", "cate", "john", "juan", "luis", "shirley", "zoe" };

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
            string[] array = {"zoe", "alice", "juan", "john", "ben", "shirley", "cate", "luis"};

            QuickSort<string>.Median3Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectStr[i], array[i]);
            }
        }
    }
}
