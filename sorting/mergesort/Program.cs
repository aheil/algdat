using System;

namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            var rnd = new Random(1337);
            var items = new int[10];
            for (int i = 0; i <= 9; i++)
            {
                items[i] = rnd.Next(100);
            }

            Write("Input:", items);

            int[] sortedItems = MergeSort(items);

            Write("Output:", sortedItems);
        }

        public static int[] MergeSort(int[] items) 
        {
            if (items.Length <= 1)
                    return items;

            // split unsorted list
            int pos = items.Length / 2;

            int[] left = new int[pos];
            int[] right = new int[items.Length - pos];

            for (int i = 0; i < pos; i++)
                left[i] = items[i];

            for (int i = pos; i < items.Length; i++)
                right[i-pos] = items[i];

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right); 
        }

        public static int[] Merge(int[] left, int[] right)
        {
            int[] sortedList = new int[left.Length + right.Length];

            int offset = 0;
            int leftOffset = 0;
            int rightOffset = 0;

            while (leftOffset < left.Length ||  rightOffset < right.Length)
            {
                if (leftOffset < left.Length && rightOffset < right.Length)
                {
                    if (left[leftOffset] <= right[rightOffset])
                    {
                        sortedList[offset++] = left[leftOffset++];
                    }
                    else
                    {
                        sortedList[offset++] = right[rightOffset++];
                    }
                }
                else if (leftOffset < left.Length)
                {
                    sortedList[offset++] = left[leftOffset++];
                }
                else if (rightOffset < right[rightOffset])
                {
                    sortedList[offset++] = right[rightOffset++];
                }
            }

            return sortedList;
        }

        public static void Write(string label, int[] items)
        {
            System.Console.Write(label + "\t");
            for (int i = 0; i < 9; i++)
            {
                System.Console.Write(items[i] + ", ");
            }
            System.Console.WriteLine(items[9]);
        }
    }
}
