using System;

namespace fibonaccisearch
{
    class Program
    {
        static int[] _fib; 

        static void Main(string[] args)
        {
            _fib = createFib(20);

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


            fibsearch(x, a);

        }

        static int[]  createFib(int length)
        {
            var fib = new int[length];

            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i < fib.Length; i++)
            {
                fib[i] = fib[i-1] + fib[i - 2];
            }

            return fib;
        }


        static void fibsearch(int x, int[] a)
        {
            int m = fibsearch_rec(x, a, 0, a.Length - 1);

            System.Console.WriteLine(String.Format("Element looked for: {0}", x));
              if (m < 0)
            System.Console.WriteLine("Element not found");
               else
                     System.Console.WriteLine(String.Format("Element found at position {0} is {1}", m, a[m]));
        }

        static int fibsearch_rec(int x, int[] a, int l, int r )
        {
            int k = 0;

            // start with a Fibonacci number greater than the array 
            while (_fib[k] < r - l)
                k++;

            if (x == a[l + _fib[--k]])
                return l + _fib[--k];

            if (r <= l)
                return -1;

            if (x < a[l + _fib[k]])
                return fibsearch_rec(x, a, l, l + _fib[k] - 1);

            return fibsearch_rec(x, a, l + _fib[k] + 1, r);

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
