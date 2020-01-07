using System;

namespace DataStructuresAlgorithms
{
    public static class HeapSort<T> where T : IComparable<T>
    {
        public static void Inplace(T[] array)
        {

        }

        private static void BubbleDown(T[] array, int k)
        {

        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
