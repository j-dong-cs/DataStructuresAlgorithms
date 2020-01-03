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
