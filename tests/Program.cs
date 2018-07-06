using System;
using System.Diagnostics;
using aheil.AlgDat.Sorting;

namespace aheil.AlgDat.Tests 
{
    public class Program
    {
        /// <summary>
        /// Test Runner for implementations in the teaching examples, 
        /// </summary>
        static void Main(string[] args)
        {
            var testRunner = new TestRunner();

            var unsortedList = testRunner.InitArray();
            var radixSort = new RadixSort();
            var sortedList = RadixSort.Sort(unsortedList);

            Debug.Assert(testRunner.Verify(sortedList));
        }
    }
}
