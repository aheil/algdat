using System;

namespace shellsort
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            var rnd = new Random(1337);
            var items = new int[10];
            for (int k = 0; k <= 9; k++)
            {
                items[k] = rnd.Next(100);
            }

            Write("Input:", items);

            int i;
            int j;
            int temp;

            int inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < items.Length; i++)
                {
                    j = i;
                    temp = items[i];
                    while ((j >= inc) && (items[j - inc] > temp))
                    {
                        items[j] = items[j - inc];
                        j = j - inc;
                    }
                    items[j] = temp;
                }


                if (inc / 2 != 0)
                {
                    inc = inc / 2;
                }
                else if (inc == 1)
                {
                    inc = 0;
                }
                else
                {
                    inc = 1;
                }
                Write("Step: ", items);
            }


         

            Write("Output:", items);
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
