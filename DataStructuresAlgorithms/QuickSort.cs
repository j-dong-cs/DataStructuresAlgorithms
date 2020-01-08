using System;

namespace DataStructuresAlgorithms
{
    /*
     * QuickSort implemention with shuffling and median-of-3 optimization.
     *
     * Average : O (n * logn)
     * Worst : O (n2) -> rarely with proper shuffling
     * 
     * Not stable, in-place sort
     */
    public static class QuickSort<T> where T : IComparable<T>
    {
        public static void ThreeWayRadixSort(string[] array)
        {
            if (array == null || array.Length <= 1) return;
            RadixSortHelper(array, 0, array.Length - 1, 0);
        }

        private static void RadixSortHelper(string[] array, int lo, int hi, int d)
        {
            if (hi <= lo) return;
            int pivot = CharAt(array[lo], d);

            // 3-way partition on dth character
            int i = lo + 1, lt = lo, gt = hi;
            while (i <= gt)
            {
                int cur = CharAt(array[i], d);
                if (cur < pivot)
                {
                    Swap(array, lt++, i++);
                }
                else if (cur > pivot)
                {
                    Swap(array, i, gt--);
                }
                else
                {
                    i++;
                }
            }

            // recursively conduct 3-way partition on sub-arrays
            RadixSortHelper(array, lo, lt - 1, d);
            if (pivot != -1) RadixSortHelper(array, lt, gt, d + 1);
            RadixSortHelper(array, gt + 1, hi, d);
        }

        private static void Swap(string[] array, int i, int j)
        {
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }
            else
            {
                return -1;
            }
        }

        // Performs efficiently in array with duplicate items.
        // Best:    O (n)
        // Average: O (2nlnn)
        // Worst:   O (1/2 n2)
        public static void ThreeWaySort(T[] array)
        {
            if (array == null || array.Length == 0) return;
            Shuffle(array);
            ThreeWaySortHelper(array, 0, array.Length - 1);
        }
        // lo       lt      gt      hi
        // |   <V   |   =V  |   >v  |
        private static void ThreeWaySortHelper(T[] array, int lo, int hi)
        {
            if (hi <= lo) return;
            T pivot = array[lo];

            int i = lo + 1, lt = lo, gt = hi;
            while (i <= gt)
            {
                if (pivot.CompareTo(array[i]) < 0)
                {
                    Swap(array, i, gt--);
                }
                else if (pivot.CompareTo(array[i]) > 0)
                {
                    Swap(array, lt++, i++);
                }
                else
                {
                    i++;
                }
            }

            ThreeWaySortHelper(array, lo, lt - 1);
            ThreeWaySortHelper(array, gt + 1, hi);
        }

        // Given an array of n items, find item of rank k in aescending order.
        // QuickSelect takes linear time on average
        public static T QuickSelectAscending(T[] array, int k)
        {
            Shuffle(array);
            int lo = 0, hi = array.Length - 1;

            while (hi > lo)
            {
                int pivot = Partition(array, lo, hi);
                if (pivot < k)
                {
                    lo = pivot + 1;
                }
                else if (pivot > k)
                {
                    hi = pivot - 1;
                }
                else // pivot = k
                {
                    return array[k];
                }
            }

            return array[k];
        }

        // Find the top k item in descending order from array.
        public static T QuickSelectDescending(T[] array, int k)
        {
            Shuffle(array);
            int n = array.Length;
            k = n - 1 - k;
            int lo = 0, hi = n - 1;

            while (hi > lo)
            {
                int pivot = Partition(array, lo, hi);
                if (pivot < k)
                {
                    lo = pivot + 1;
                }
                else if (pivot > k)
                {
                    hi = pivot - 1;
                }
                else // pivot = k
                {
                    return array[k];
                }
            }

            return array[k];
        }

        public static void Median3Sort(T[] array)
        {
            if (array == null || array.Length == 0) return;
            Shuffle(array);
            Median3Sort(array, 0, array.Length - 1);
        }

        private static void Median3Sort(T[] array, int lo, int hi)
        {
            if (hi <= lo) return;

            int median = FindMedian3(array, lo, lo + (hi - lo)/2, hi);
            Swap(array, lo, median);

            int j = Partition(array, lo, hi);

            Median3Sort(array, lo, j - 1);
            Median3Sort(array, j + 1, hi);
        }

        private static int Partition(T[] array, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;

            while (true)
            {
                while (array[++i].CompareTo(array[lo]) < 0) if (i == hi) break;

                while (array[--j].CompareTo(array[lo]) > 0) if (j == lo) break;

                if (i >= j) break;

                Swap(array, i, j);
            }

            Swap(array, lo, j);

            return j;
        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static int FindMedian3(T[] array, int lo, int mid, int hi)
        {
            return (array[lo].CompareTo(array[mid]) < 0 ?
                (array[mid].CompareTo(array[hi]) < 0 ? mid : array[lo].CompareTo(array[hi]) < 0 ? hi : lo) :
                (array[hi].CompareTo(array[mid]) < 0 ? mid : array[hi].CompareTo(array[lo]) < 0 ? hi : lo));
        }

        // Fisher-yates shuffle 
        private static void Shuffle(T[] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i, rand.Next(i + 1));
            }
        }
    }
}
