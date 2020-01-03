using System;

namespace DataStructuresAlgorithms
{
    /*
     * Selection Sort implementation.
     *
     * O (n2)
     * 
     */
    public static class SelectionSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] array)
        {
            int size = array.Length;

            for (int i = 0; i < size; i++)
            {
                int min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }
                Swap(array, i, min);
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
