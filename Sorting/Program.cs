
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SortingTechniques
    {
        static void Main(string[] args)
        {
            var input = new int[] { 7,1,13,9,8,15,2,6,5,3};
            //var output = SelectionSort(input);

            //var output = BubbleSort(input);

            //var output = MergeSort(input);

            var output = QuickSort(input);

            Console.Write(string.Join(",", output));

            Console.ReadLine();
        }

        private static int[] SelectionSort(int[] data)
        {
            int min_index = -1;
            int length= data.Length;

            for(int i=0; i<length; i++)
            {
                min_index = i;

                for(int j=i+1; j<length; j++)
                {
                    if (data[j]< data[min_index])
                    {
                        min_index=j; 
                    }
                }

                //make a swap
                int temp = data[i];
                data[i] = data[min_index];
                data[min_index] = temp;

            }
            return data;
        }

        private static int[] BubbleSort(int[] data)
        {
            int n = data.Length;
            bool swapped = false;
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n-i-1; j++)
                {
                    if (data[j]> data[j+1])
                    {
                        int temp= data[j];
                        data[j] = data[j + 1];
                        data[j+1] = temp;

                        swapped = true;
                    }
                }

                if(!swapped)
                {
                    break;
                }
            }

            return data;
        }

        private static int[] Insertion(int[] data)
        {
            return data;
        }

        private static int[] MergeSort(int[] data)
        {
            MergeSorting(data, 0, data.Length - 1);
            return data;
        }

        private static void MergeSorting(int[] data, int l, int r)
        {
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                MergeSorting(data, l, m);
                MergeSorting(data, m + 1, r);

                // Merge the sorted halves
                Merge(data, l, m, r);
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        private static int[] QuickSort(int[] data)
        {
            QuickSorting(data, 0, data.Length - 1);
            return data;
        }

        private static void QuickSorting(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is the partition return index of pivot
                int pi = Partition(arr, low, high);

                // Recursion calls for smaller elements
                // and greater or equals elements
                QuickSorting(arr, low, pi - 1);
                QuickSorting(arr, pi + 1, high);
            }
        }

        private static int Partition(int[] data, int low, int high)
        {
            int pivot = data[high];

            int i = low - 1;

            for(int j=low; j<=high-1; j++)
            {
                if (data[j]< pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            // Move pivot after smaller elements and
            // return its position
            Swap(data, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static int[] HeapSort(int[] data)
        {
            return data;
        }
    }
  
}