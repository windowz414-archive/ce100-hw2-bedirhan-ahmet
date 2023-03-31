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

        // Helper function for HeapSort. This MUST NOT be documented!
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

        // Helper function for HeapSort and Heapify. This MUST NOT be documented!
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /**
         * This function calculates the minimum number of scalar multiplications required to multiply the matrices
         * together in the given order.
         * 
         * @param p An array that represents the dimensions of n matrices.
         * @return Minimum number of scalar multiplications required to multiply the matrices together in the given order.
         */
        public static int MatrixChainOrderDP(int[] p)
        {
            int n = p.Length - 1;

            // m[i,j] stores the minimum number of scalar multiplications required to compute A[i..j].
            int[,] m = new int[n, n];

            // s[i,j] stores the index that splits the product A[i..j] into two subproducts.
            int[,] s = new int[n, n];

            // Initialize m[i,i] to 0 for all i.
            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            // Compute m[i,j] and s[i,j] for all i < j.
            for (int L = 2; L <= n; L++)
            {
                for (int i = 0; i < n - L + 1; i++)
                {
                    int j = i + L - 1;
                    m[i, j] = int.MaxValue;

                    for (int k = i; k < j; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i] * p[k + 1] * p[j + 1];

                        if (q < m[i, j])
                        {
                            m[i, j] = q;
                            s[i, j] = k;
                        }
                    }
                }
            }

            // Return the minimum number of scalar multiplications required to compute A[1..n].
            return m[0, n - 1];
        }
    }
}
