using System;

namespace DataStructuresAlgorithms
{
    /*
     * Generic MergeSort class which provides two implementation:
     * Topdown and Bottomup.
     * 
     * Stable: preserves the relative order of equal keys.
     * 
     * O(n * logn)
     */
    public static class MergeSort<T> where T : IComparable<T>
    {
        public static void BottomUpSort(T[] a)
        {
            T[] aux = new T[a.Length];
            for (int len = 1; len < a.Length; len *= 2)
            {
                for (int lo = 0; lo < a.Length - len; lo += len+len)
                {
                    int mid = lo + len - 1;
                    int hi = Math.Min(lo + len + len - 1, a.Length - 1);
                    Merge(a, aux, lo, mid, hi);
                }
            }
        }

        // This method sort an generic array with mergesort top-down(divide-conquer) implementation.
        public static void TopDownSort(T[] a)
        {
            T[] aux = new T[a.Length];
            TopDownSort(a, aux, 0, a.Length - 1);
        }

        private static void TopDownSort(T[] a, T[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;

            TopDownSort(a, aux, lo, mid);
            TopDownSort(a, aux, mid + 1, hi);

            // if array is already sorted, copy array and avoid merge
            if (a[mid].CompareTo(a[mid + 1]) <= 0)
            {
                Array.Copy(a, lo, aux, lo, hi - lo + 1);
            }

            Merge(a, aux, lo, mid, hi);
        }

        private static void Merge(T[] a, T[] aux, int lo, int mid, int hi)
        {
            // copy 'a' into 'aux'
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k<= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                else if (aux[i].CompareTo(aux[j]) <= 0)
                {
                    a[k] = aux[i++];
                }
                else
                {
                    a[k] = aux[j++];
                }
            }
        }
    }
}
