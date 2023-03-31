using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static ce100_hw2_algo_lib_cs.ce100_hw2_algo_lib;

namespace ce100_hw2_algo_test_cs
{
    [TestClass]
    public class ce100_hw2_algo_test_cs
    {
        [TestMethod]
        public void TestHeapSort()
        {
            Random rand = new Random();

            // Test best-case scenario (already sorted array)
            for (int i = 0; i < 1000; i++)
            {
                int[] input = Enumerable.Range(0, rand.Next(1, 1001)).ToArray();
                int[] expectedOutput = (int[])input.Clone();
                Array.Sort(expectedOutput);

                int[] actualOutput = HeapSort(input);

                for (int j = 0; j < input.Length; j++)
                {
                    Assert.AreEqual(expectedOutput[j], actualOutput[j]);
                }
            }

            // Test average-case scenario (random unsorted array)
            for (int i = 0; i < 1000; i++)
            {
                int[] input = Enumerable.Range(0, rand.Next(1, 1001)).Select(j => rand.Next(int.MinValue, int.MaxValue)).ToArray();
                int[] expectedOutput = (int[])input.Clone();
                Array.Sort(expectedOutput);

                int[] actualOutput = HeapSort(input);

                for (int j = 0; j < input.Length; j++)
                {
                    Assert.AreEqual(expectedOutput[j], actualOutput[j]);
                }
            }

            // Test worst-case scenario (reverse sorted array)
            for (int i = 0; i < 1000; i++)
            {
                int[] input = Enumerable.Range(0, rand.Next(1, 1001)).Select(j => 1000 - j).ToArray();
                int[] expectedOutput = (int[])input.Clone();
                Array.Sort(expectedOutput);

                int[] actualOutput = HeapSort(input);

                for (int j = 0; j < input.Length; j++)
                {
                    Assert.AreEqual(expectedOutput[j], actualOutput[j]);
                }
            }
        }
    }
}
