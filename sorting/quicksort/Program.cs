using System;

namespace quicksort
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
            QuickSort(items, 0, items.Length - 1);
            Write("Output:", items);
        }

        private static void QuickSort(int[] items, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(items, left, right);

                Write("Step:", items);

                if (pivot > 1)
                    QuickSort(items, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort(items, pivot + 1, right);
            }
        }

        private static int Partition(int[] items, int left, int right)
        {
            int pivot = items[left];
            while (true)
            {
                while (items[left] < pivot)
                    left++;

                while (items[right] > pivot)
                    right--;

                if (left < right)
                {
                    if (items[left] == items[right]) 
                        return right;

                    int temp = items[left];
                    items[left] = items[right];
                    items[right] = temp;
                }
                else
                {
                    return right;
                }
            }
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
