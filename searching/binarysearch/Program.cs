using System;

namespace binarysearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[100];

            var rnd = new Random();
            for (int p = 0; p < 100; p++)
            {
                a[p] = rnd.Next(100);
            }

            // pick random element to search for
            var x = a[rnd.Next(a.Length)];

            // sort elements
            a = sort(a);

            int l = 0; 
            int r = a.Length - 1; 
            bool found = false;
            int m = -1;

            while (l <= r && !found)
            {
                m = l + ((r - l)/2); // choose the middle element
                if (a[m] == x)
                {
                    found = true;
                }
                else
                {
                    if (a[m] < x)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
               
            }

            System.Console.WriteLine(String.Format("Element looked for: {0}", x));
            if (!found)
                System.Console.WriteLine("Element not found");
            else
                System.Console.WriteLine(String.Format("Element found at position {0} is {1}", m, a[m]));

        }

        static int[] sort(int[] a) 
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }

                }
                int tmp = a[min];
                a[min] = a[i];
                a[i] = tmp;
            }
            return a;
        }
    }
}
