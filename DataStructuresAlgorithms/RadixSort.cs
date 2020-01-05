using System;

namespace DataStructuresAlgorithms
{
    /*
     * RadixSort implemtation including
     * Least-significant-digit-first (LSD) radix sort
     * Guarantee: O (2wn)
     * Random: O (2wn)
     * Space: n+R
     * 
     * Most-significant-digit-first (MSD) radix sort
     * Guarantee: O (2wn)
     * Random: O (nlogrn)
     * Space: n + DR
     */
    public static class RadixSort
    {
        private static readonly int R = 256;

        public static void LSD(string[] a, int w)
        {
            int n = a.Length;
            string[] aux = new string[n];

            // sort each string starting with last indexed char
            for (int d = w - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];

                // count frequencies of each letter using key as index
                for (int i = 0; i < n; i++)
                {
                    count[a[i][d] + 1]++;
                }
                // compute frequency cumulates which specify destinations
                for (int r = 0; r < R; r++)
                {
                    count[r + 1] += count[r];
                }
                // access cumulates using key as index to move items
                for (int i = 0; i < n; i++)
                {
                    aux[count[a[i][d]]++] = a[i];
                }
                // copy back to original array
                for (int i = 0; i < n; i++)
                {
                    a[i] = aux[i];
                }
            }
        }

        public static void MSD(string[] a)
        {
            string[] aux = new string[a.Length];
            Sort(a, aux, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, string[] aux, int lo, int hi, int d)
        {
            if (hi <= lo) return;

            // partition array into R pieces according to first character
            int[] count = new int[R + 2];

            for (int i = lo; i <= hi; i++)
            {
                count[CharAt(a[i], d) + 2]++;
            }
            for (int r = 0; r < R + 1; r++)
            {
                count[r + 1] += count[r];
            }
            for (int i = lo; i <= hi; i++)
            {
                aux[count[CharAt(a[i], d) + 1]++] = a[i];
            }
            for (int i = lo; i <= hi; i++)
            {
                a[i] = aux[i - lo];
            }

            Console.WriteLine();
            foreach (string s in a)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();

            for (int r = 0; r < R; r++)
            {
                Sort(a, aux, lo + count[r], lo + count[r+1] - 1, d + 1);
            }
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
    }
}
