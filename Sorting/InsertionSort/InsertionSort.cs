using System;

namespace aheil.AlgDat.Sorting
{
    public class InsertionSort
    {
        public int[] Sort (int [] items)
        {
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
            }
            return items;
        }
    }
}
