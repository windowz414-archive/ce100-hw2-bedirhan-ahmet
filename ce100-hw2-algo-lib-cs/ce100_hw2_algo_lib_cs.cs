/**
 * Copyright (C) 2023 Beru Hinode. All Rights Reserved.
 *
 * SPDX-License-Identifier: GPL-2.0-only
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw2_algo_lib_cs
{
    public class ce100_hw2_algo_lib
    {
        /**
         * This function sorts an array of integers using heap sort method.
         * 
         * @param array The input array that needs to be sorted.
         * @return Sorted array of integers.
         */
        public static int[] HeapSort(int[] array)
        {
            // Build heap
            for (int i = (array.Length - 1) / 2; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }

            // Sort heap
            for (int i = array.Length - 1; i >= 1; i--)
            {
                Swap(array, 0, i);
                Heapify(array, i, 0);
            }

            return array;
        }

        private static void Heapify(int[] array, int size, int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < size && array[leftChild] > array[largest])
            {
                largest = leftChild;
            }

            if (rightChild < size && array[rightChild] > array[largest])
            {
                largest = rightChild;
            }

            if (largest != index)
            {
                Swap(array, index, largest);
                Heapify(array, size, largest);
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
