using System;

namespace radixsort
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            var rnd = new Random(1337);
            var items = new int[20];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = rnd.Next(100);
            }

            Write("Input:", items);
            int[] sortedItems =  RadixSort(items);
            Write("Output:", sortedItems);


            // Write("Output:", sortedItems);
        }

        // this radixsort implementation is not optmial, it is simply
        // implemented to understand the algorith-m
        public static int[] RadixSort(int[] items)
        {
            int runs = getMaxDigits(items);

            // base 10 - decimal values
            var buckets = new int[10][]; 
            var counter = new int[10];

            // worst-case number of items in one bucket
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new int[items.Length];

            for (int r = 0; r < runs; r++)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    int tmp = items[i] / (int)Math.Pow(10, r);
                    int key = tmp % (10);
                    buckets[key][counter[key]++] = items[i];
                    //System.Console.WriteLine("Run " + r + " Number: " + items[i] + " Key " + key);
                }


                // write buckets: 
                //for (int i = 0; i < buckets.Length; i++)
                //{
                //    System.Console.WriteLine("Run: " + r + " Bucket: " + i);
                //    for (int j = 0; j < counter[i]; j++)
                //    {
                //        System.Console.Write(" " + buckets[i][j]);
                //    }
                //    System.Console.WriteLine();
                //}

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

        public static int getMaxDigits(int[] items)
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

        public static void Write(string label, int[] items)
        {
            System.Console.Write(label + "\t");
            for (int i = 0; i < items.Length; i++)
            {
                System.Console.Write(items[i] + ", ");
            }
            System.Console.WriteLine(items[items.Length - 1]);
        }
    }
}
