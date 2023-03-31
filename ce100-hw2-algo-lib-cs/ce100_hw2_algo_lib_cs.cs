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

        /**
         * Computes the length of the longest common subsequence between two strings using dynamic programming.
         * 
         * @param s1 The first input string.
         * @param s2 The second input string.
         * @return The length of the longest common subsequence between `s1` and `s2`.
         */
        public static int LongestCommonSubsequence(string s1, string s2)
        {
            int[,] lengths = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        lengths[i, j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        lengths[i, j] = lengths[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lengths[i, j] = Math.Max(lengths[i - 1, j], lengths[i, j - 1]);
                    }
                }
            }

            return lengths[s1.Length, s2.Length];
        }

        /**
         * Computes the maximum value that can be obtained by filling a knapsack with a given weight capacity.
         * @brief 0-1 Knapsack problem using dynamic programming.
         * 
         * @param W The maximum weight capacity of the knapsack.
         * @param wt An array of item weights.
         * @param val An array of item values.
         * @param n The number of items.
         * @return The maximum value that can be obtained by filling the knapsack with items.
         */
        public static int KnapsackProblem(int W, int[] wt, int[] val, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }
    }
}
