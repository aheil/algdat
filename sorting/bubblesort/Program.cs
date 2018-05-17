using System;

namespace bubblesort
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

            bool switched = false;
            do
            {
                switched = false;
                for (int i = 0; i <= items.Length - 2; i++)
                {
                    if (items[i] > items[i + 1])
                    {
                        var temp = items[i + 1];
                        items[i + 1] = items[i];
                        items[i] = temp;
                        switched = true;
                    }
                }
                Write("Step: ", items);
            } while (switched);

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
