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
        public static void ThreeWaySort(T[] array)
        {

        }

        public static void Median3Sort(T[] array)
        {
            if (array == null || array.Length == 0) return;

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
    }
}
