using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class ElementarySortTests
    {
        public static readonly int[] expectInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public static readonly string[] expectStr = { "alice", "ben", "cate", "john", "juan", "luis", "shirley", "zoe" };

        [Fact]
        public void BinaryInsertionSortIntTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };
            InsertionSort<int>.BinaryInsertion(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectInt[i], array[i]);
            }
        }

        [Fact]
        public void BinaryInsertionSortStrTest()
        {
            string[] array = { "zoe", "alice", "juan", "john", "ben", "shirley", "cate", "luis" };
            InsertionSort<string>.BinaryInsertion(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectStr[i], array[i]);
            }
        }

        [Fact]
        public void SelectionSortIntTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };

            SelectionSort<int>.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectInt[i], array[i]);
            }
        }

        [Fact]
        public void SelectionSortStrTest()
        {
            string[] array = { "zoe", "alice", "juan", "john", "ben", "shirley", "cate", "luis" };

            SelectionSort<string>.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectStr[i], array[i]);
            }
        }

        [Fact]
        public void InsertionSortIntTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };

            InsertionSort<int>.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectInt[i], array[i]);
            }
        }

        [Fact]
        public void InsertionSortStrTest()
        {
            string[] array = { "zoe", "alice", "juan", "john", "ben", "shirley", "cate", "luis" };

            InsertionSort<string>.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectStr[i], array[i]);
            }
        }
    }
}
