using System;

namespace aheil.AlgDat.Tests
{
    public class TestRunner
    {
        public TestRunner() {}
    
        public int[] InitArray()
        {

            var rnd = new Random(1337);
            var items = new int[100];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = rnd.Next(100);
            }

            return items;
        }

        public bool Verify(int[] sortedList) {

            for (int i = 1; i < sortedList.Length; i++)
            {
                if (sortedList[i - 1] > sortedList[i])
                    return false;
            }
            return true;
        }
    }
}