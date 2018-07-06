using System;

namespace heapsort
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

            var heapSort = new HeapSort();
            var result = heapSort.Sort(items);

            Write("Output:", result);

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

    class HeapSort
    {
        int[] _heap = null;
        int _heapSize = 0;

       public int[] Sort(int[] items)
       {
            _heap = items;
            BuildHeap();
            for (int i = _heap.Length - 1; i >= 0; i--)
            {
                int temp = _heap[0];
                _heap[0] = _heap[i];
                _heap[i] = temp;
                _heapSize--;
                Heapify(0);
            }
            return _heap;
       }

        void BuildHeap()
        {
            _heapSize = _heap.Length - 1;
            for (int i = _heapSize / 2; i >= 0; i--)
                Heapify(i);
        }

        void Heapify(int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= _heapSize && _heap[left] > _heap[index])
            {
                largest = left;
            }

            if (right <= _heapSize && _heap[right] > _heap[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                int temp = _heap[index];
                _heap[index] = _heap[largest];
                _heap[largest] = temp;
               
                Heapify(largest);
            }

        }
    }
}
