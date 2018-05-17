using System;

namespace insertsort
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

            for (int i = 0; i < items.Length - 1; i++) 
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (items[j - 1] > items[j])
                    {
                        int tmp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = tmp;
                    }
                }
                Write("Step: ", items);
            }

            Write("Output:", items);
        }

        public static void Write(string label, int[] items)
        {
            System.Console.Write(label + "\t");
            for (int i = 0; i < 9; i++) {
                System.Console.Write(items[i] + ", ");
            }
            System.Console.WriteLine(items[9]);
        }

    }
}
