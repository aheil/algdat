using System;

namespace sequentialsearch
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

            //sequentialsearch
            int i = 0;
            while(i < a.Length && a[i] != x) 
            {
                i++;
            } 

            System.Console.WriteLine(String.Format("Element looked for: {0}", x));

            if (i == a.Length)
                System.Console.WriteLine("Element not found");
            else
                System.Console.WriteLine(String.Format("Element found at position {0} is {1}", i, a[i]));
        }
    }
}
