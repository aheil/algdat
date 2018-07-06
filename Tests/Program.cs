using System;
using System.Diagnostics;
using aheil.AlgDat.Sorting;

namespace aheil.AlgDat.Tests 
{
    public class Program
    {
        static TestRunner _testRunner = null;
        /// <summary>
        /// Test Runner for implementations in the teaching examples, 
        /// </summary>
        static void Main(string[] args)
        {
             _testRunner = new TestRunner();

            RadixSortTest();
        }

        private static void InsertionSortTest()
        {
            var unsortedList = _testRunner.InitArray();
            var insertionSort = new InsertionSort();
            var sortedList = insertionSort.Sort(unsortedList);

            Debug.Assert(_testRunner.Verify(sortedList));

        }

        private static void RadixSortTest()
        {
            var unsortedList = _testRunner.InitArray();
            var radixSort = new RadixSort();
            var sortedList = radixSort.Sort(unsortedList);

            Debug.Assert(_testRunner.Verify(sortedList));
        }
    }
}