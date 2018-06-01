using System;

namespace tabellensuche
{
    class Program
    {
        static void Main(string[] args)
        {
            // due to example code we assume search key and strings are same length
            string[] t = { "abc", "def", "ghi", "jkl", "kno", "pqr", "stu", "vwx", "xy_", "!?-"};
            string x = "vwx";


            int l = 0;
            int r = t.Length;
            //bool found = false;
            int i = 0;
            int m = -1;

            while (l < r)
            {
                m = (l + r) / 2;
                i = 0;
                while (i < x.Length-1 && t[m][i] == x[i] /* && x[i] != 0xC0*/)
                {
                    i++; // as long as chars are the same  
                }
                if (t[m][i] < x[i]) 
                {
                    l = m + 1;  //char smaller than the char at search string at same position
                }
                else
                {
                    r = m;     // otherwise 
                }
            }

            if (r < t.Length)
            {
                i = 0;
                while (i < x.Length-1 && t[r][i] == x[i] /* x[i] != 0x0C*/)
                {
                    i++;
                }
                System.Console.WriteLine(r);
                // found = x[i] == 0x0C; 
            }
        }
   }
}

