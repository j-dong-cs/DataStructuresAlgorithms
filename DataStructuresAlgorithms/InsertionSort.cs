using System;

namespace DataStructuresAlgorithms
{
    /*
     * Insertion sort implementation.
     *
     * O (n2)
     *
     * Runs in linear time on partially sorted arrays.
     * Improved through Half exchanges and Binary insertion sort.
     */
    public static class InsertionSort<T> where T : IComparable<T>
    {
        // Sort an array using an optimized binary insertion sort with half exchanges
        public static void BinaryInsertion(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int lo = 0, hi = i;
                T cur = array[i];

                while (lo < hi)
                {
                    // binary search to determine index j at which to insert a[i]
                    int mid = lo + (hi - lo) / 2;
                    if (cur.CompareTo(array[mid]) < 0)
                    {
                        hi = mid;
                    }
                    else if (cur.CompareTo(array[mid]) > 0)
                    {
                        lo = mid + 1;
                    }
                }

                // insert a[i] at index j and shift a[j] .. a[i-1] to the right
                for  (int j = i; j > lo; j--)
                {
                    array[j] = array[j - 1];
                }
                array[lo] = cur;
            }
        }

        public static void Sort(T[] array)
        {
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Swap(array, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
