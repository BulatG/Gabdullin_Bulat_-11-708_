using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_3_.cs
{
    public class Intro
    {

        public static void Sort(int[] array)
        {
            int depth = ((int)Math.Log(array.Length)) * 2;
            Sort(array, depth, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int depth, int left, int right)
        {
            int length = array.Length;
            if (length <= 1)
                return;
            else if (depth == 0)
                HeapSort(array, left, right);
            else
            {
                if (left <= right)
                    return;
                int index = Partition(array, left, right);
                Sort(array, depth - 1, left, index - 1);
                Sort(array, depth - 1, index, right);
            }
        }

        private static void HeapSort(int[] array, int left, int right)
        {
            for (int i = right / 2 - 1; i >= left; i--)
                Heapify(array, right, i);
            for (int i = right - 1; i >= left; i--)
            {
                Swap(array, left, i);
                Heapify(array, i, left);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && array[l] > array[largest])
                largest = l;
            if (r < n && array[r] > array[largest])
                largest = r;
            if (largest != i)
            {
                Swap(array, i, largest);
                Heapify(array, n, largest);
            }
        }

        public static int Partition(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];

            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }
}