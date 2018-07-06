using System;

namespace aheil.AlgDat.Sorting
{
    public class RadixSort
    {
        // this radixsort implementation is not optmial, it is simply
        // implemented to understand the algorithm
        public int[] Sort(int[] items)
        {
            // for each digit we need one run 
            int runs = getMaxDigits(items);

            // base 10 - decimal values
            var buckets = new int[10][]; 
            var counter = new int[10];

            // worst-case number of items in one bucket
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new int[items.Length];

            // one run per digit
            for (int r = 0; r < runs; r++)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    int tmp = items[i] / (int)Math.Pow(10, r);
                    int key = tmp % (10);
                    buckets[key][counter[key]++] = items[i];
                }

                items = new int[items.Length];
                int c = 0;

                for (int i = 0; i < buckets.Length; i++)
                {
                    for (int j = 0; j < counter[i]; j++)
                    {
                        items[c++] = buckets[i][j];
                    }
                    // reset bucket
                    buckets[i] = new int[items.Length];
                    counter[i] = 0;
                }
            }

            return items;
        }

        private int getMaxDigits(int[] items)
        {
            int n = 0;
            int runs = 0;
            for (int i = 0; i < items.Length; i++)
            {
                n = (int)Math.Ceiling(Math.Log10(items[i]));
                if (n > runs)
                    runs = n;
            }
            return runs;
        }
    }
}
