using System;

namespace ConsoleApp4
{
    class Program
    {
        static int[] HybridSort(int[] arr, int threshold)
        {
            int[] sortedArr = (int[])arr.Clone();
            if (sortedArr.Length <= threshold)
            {
                SelectionSort(sortedArr);
            }
            else
            {
                QuickSort(sortedArr, 0, sortedArr.Length - 1, threshold);
            }
            return sortedArr;
        }

        private static void QuickSort(int[] arr, int left, int right, int threshold)
        {
            if (left < right)
            {
                if (right - left + 1 <= threshold)
                {
                    SelectionSort(arr, left, right);
                }
                else
                {
                    int pivot = Partition(arr, left, right);
                    QuickSort(arr, left, pivot - 1, threshold);
                    QuickSort(arr, pivot + 1, right, threshold);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            return i + 1;
        }

        private static void SelectionSort(int[] arr, int left, int right)
        {
            for (int i = left; i <= right; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= right; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(arr, i, minIndex);
            }
        }

        private static void SelectionSort(int[] arr)
        {
            SelectionSort(arr, 0, arr.Length - 1);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        static void Main(string[] args)
        {
            int[] arr = { 5, 1, 7, 3, 9, 2 };
            int[] arr_sorted = HybridSort(arr, 5);
            Console.WriteLine(string.Join(", ", arr_sorted));
        }
    }
}