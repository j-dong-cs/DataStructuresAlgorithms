using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms;

namespace Tests
{
    public class RadixSortTests
    {
        public static readonly string[] expectSeq = { "aaa", "aac", "aba", "bcb", "bde", "bgp", "cpd", "elk", "exk", "opq" };
        public static readonly string[] expectName = { "abbey", "alex", "alice", "ben", "benny", "bobby", "cate", "john", "johnny", "luis", "shawn", "shirley", "zoe" };

        [Fact]
        public void LSDTest()
        {
            string[] array = { "opq", "elk", "bcb", "bde", "exk", "aba", "bgp", "aac", "aaa",  "cpd"};
            RadixSort.LSD(array, 3);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectSeq[i], array[i]);
            }
        }

        [Fact]
        public void MSDSameLengthTest()
        {
            string[] array = { "opq", "elk", "bcb", "bde", "exk", "aba", "bgp", "aac", "aaa", "cpd" };
            RadixSort.MSD(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectSeq[i], array[i]);
            }
        }

        [Fact]
        public void MSDDiffLengthTest()
        {
            string[] array = { "zoe", "alex", "luis", "ben", "johnny", "benny",  "abbey", "shawn", "alice", "shirley", "john", "bobby", "cate" };
            RadixSort.MSD(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(expectName[i], array[i]);
            }
        }
    }
}
