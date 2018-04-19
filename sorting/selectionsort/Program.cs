using System;

namespace selectionsort
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            Random rnd = new Random(1337);

            int[] item = new int[10];
            for (int i = 0; i < 10; i++)
            {
                item[i] = rnd.Next(100);
            }

            System.Console.Write("Input: ");
            for (int i = 0; i < 9; i++)
            {
                System.Console.Write(item[i] + ", ");
            }
            System.Console.WriteLine(item[9]);

            // selection sort 
            for (int i = 0; i < 10; i++)
            {
                int min = i;
                for (int j = i + 1; j < 10; j++)
                {
                    if (item[j] < item[min])
                    {
                        min = j;
                    }
                       
                }
                int tmp = item[min];
                item[min] = item[i];
                item[i] = tmp;
            }

            System.Console.Write("Output: ");
            for (int i = 0; i < 9; i++)
            {
                System.Console.Write(item[i] + ", ");
            }
            System.Console.WriteLine(item[9]);
        }
    }
}
