using System;

namespace aheil.AlgDat.Sorting
{
    public class BubbleSort
    {
        public int[] Sort(int[] item)
        {
            bool switched = false;
            do
            {
                switched = false;
                for (int i = 0; i <= item.Length - 2; i++)
                {
                    if (item[i] > item[i + 1])
                    {
                        var temp = item[i + 1];
                        item[i + 1] = item[i];
                        item[i] = temp;
                        switched = true;
                    }
                }
            } while (switched);
            return item;    
        }
    }
}
