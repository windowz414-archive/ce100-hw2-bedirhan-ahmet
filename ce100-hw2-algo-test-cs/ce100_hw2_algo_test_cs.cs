using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ce100_hw2_algo_lib_cs;

namespace ce100_hw2_algo_test_cs
{
    [TestClass]
    public class ce100_hw2_algo_test_cs
    {
        [TestMethod]
        public void TestheapSort()
        {
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                // Generate random input array
                int[] input = Enumerable.Range(0, rand.Next(1, 1001)).Select(j => rand.Next(int.MinValue, int.MaxValue)).ToArray();

                // Test heap sort algorithm
                int[] actualOutput = new int[input.Length];
                int result = ce100_hw2_algo_lib.heapSort(input, actualOutput);

                Assert.AreEqual(0, result);
            }
        }

    }
}
