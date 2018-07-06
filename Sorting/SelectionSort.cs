using System;

namespace aheil.AlgDat.Sorting
{
    public class SelectionSort
    {
        public int[] Sort(int[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < item.Length; j++)
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
            return item;
        }
    }
}
