using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw2_algo_lib_cs
{
    public class ce100_hw2_algo_lib_cs
    {
        /**
         * This function sorts an array of integers using heap sort method.
         * 
         * @param inputArray The input array that needs to be sorted.
         * @param outputArray The array that will contain the sorted elements after the method is executed.
         * @return -1 if there's something wrong with parameters, 0 if the function runs successfully.
         */
        public static int heapSort(int[] inputArray, int[] outputArray)
        {
            if (inputArray == null || outputArray == null || inputArray.Length != outputArray.Length)
            {
                return -1; // Return -1 if inputArray or outputArray is null or their lengths don't match.
            }

            int n = inputArray.Length;

            // Build max heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(inputArray, n, i);
            }

            // Extract elements from heap one by one
            for (int i = n - 1; i >= 0; i--)
            {
                outputArray[i] = inputArray[0];
                inputArray[0] = inputArray[i];
                heapify(inputArray, i, 0);
            }

            return 0; // Return 0 if the function is successful.
        }

        // Helper function for heapSort. This MUST NOT be documented!
        private static void heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int l = 2 * i + 1; // Left child
            int r = 2 * i + 2; // Right child

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
            {
                largest = l;
            }

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
            {
                largest = r;
            }

            // If largest is not root
            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                // Recursively heapify the affected sub-tree
                heapify(arr, n, largest);
            }
        }

    }
}
