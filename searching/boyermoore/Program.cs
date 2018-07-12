using System;

namespace boyermoore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bm = new BoyerMooreSearch();

            string pattern = "Sonne"; // hier noch Problem, Alg. liefert bei Index 4 eine Null, laut Lösung aber eine 5 
            string text = "Sonnige Abschnitte im Schwarzwald, danach ziehen örtlich Gewitter auf und die Sonnenscheindauer beträgt ca. 5 Stunden";
            //string pattern = "Fest";
            //string text = "Ein Test als Fest.";
            //string pattern = "ABACABEF";
            //string text = "ABABACAABABABEFCABEFABACABEF";
            //string pattern = "FBBC";
            //string text = "ABABACAABABABEFCABEFABACABEF";
            //string pattern = "abbabab"; // hier noch ein Problem, liefert 1001010 nicht den Wert aus der Vorlesung 
            //string text = "aabababacbaaaabdbabababbababbdbdbbababaababbabbababbbbaaabababcbaaababa";
            //string pattern = "001010101";
            //string text = "0101010101010101010101010101";

            Example(pattern, bm);
            //ExamplePreprocessing(pattern);


            bm.InitOcc(pattern);
            bm.Preprocessing(pattern);
            bm.Search(pattern, text);
        }

        public static void ExamplePreprocessing(string pattern)
        {
            // Fall 1 

            char[] p = pattern.ToCharArray();
            int[] f = new int[p.Length + 1];

            // Für Position i beginnendes Suffix enthält der Eintrag b[i]
            // die Anfangsposition seines breitesten Rands 
            for (int i = 0; i < pattern.Length; i++)
            {
                string suffix = pattern.Substring(i, pattern.Length-i);
                System.Console.WriteLine("\nSuffix: " + suffix);

                // Ränder suchen
                int length = 1;
                for (int j = 0; j < suffix.Length-1; j++)
                {
                    string left = suffix.Substring(0, length);
                    string right = suffix.Substring(suffix.Length - length, length);
                  
                    System.Console.WriteLine();
                    System.Console.Write(" left: " + left + " right: " + right);
                   
                    // Rand gefunden, und Position setzen 
                    // (kleinere Einträge werden überschireiben)
                    if (left == right)
                        f[i] = pattern.Length - length;
                    //else
                    //    f[i] = pattern.Length;

                    length++;
                }

                // f[i] == 0? D.h. kein Rand gefunden, Rand mit Epsilon startet 
                // nach dem Zeichen
                if (f[i] == 0)
                    f[i] = pattern.Length;

                // Suffix der Länge 1 hat Rand Epsilon, beginnt bei m+1
                if (suffix.Length == 1)
                    f[i] = pattern.Length;
               
                System.Console.WriteLine();

            }

            // Für Suffix Epsilon an Position m wird f[m] = m+1 gesetzt
            f[pattern.Length] = pattern.Length + 1;



            // Berechnung von s[]
            // Für s nur die Ränder maßgeblich, die sich NICHT nach links fortsetzen lassen
            int[] s = new int[pattern.Length + 1];

            // start bei i = 1, da sich egal welcher Rand an Pos 1 nie nach links fortsetzen lässt 
            for (int i = 1; i < pattern.Length; i++)
            {
                System.Console.WriteLine("\nPosition: " + i);
                string suffix = pattern.Substring(i, pattern.Length - i);
                System.Console.WriteLine("Suffix: " + suffix);

                // Ränder suchen

                int length = 1;
                for (int j = 0; j < suffix.Length - 1; j++)
                {
                    string left = suffix.Substring(0, length);
                    string right = suffix.Substring(suffix.Length - length, length);

                    System.Console.WriteLine();
                    System.Console.Write(" left: " + left + " right: " + right);

                    // Rand gefunden ?
                    if (left == right)
                    {
                        // lässt sich der Rand fortsetzen
                        if (p[i - 1] == p[pattern.Length - length - 1])
                        {
                            // ignorieren
                        }
                        else
                        {
                            System.Console.WriteLine("\nNicht Forsetzbar: " + p[i - 1] + " - " + p[suffix.Length - length - 1]);
                            int randPosition = (pattern.Length - length);
                            System.Console.WriteLine("Rand " + left + " start bei " + randPosition);                  
                            int tmp = (pattern.Length - length) - i;  
                            s[randPosition]  = tmp;
                        }
                    }
                    length++;
                }
            }

            // Der Eintrag s[max] = 1 kommt zustande, weil das an Position pattern.Length 
            // beginnende Suffix  den an Position max beginnenden Rand ε hat und sich dieser nicht fortsetzen lässt.
            s[pattern.Length] = 1;


            // f[0] erhält die Startposition des breitestens Randes für das ganze Wort 
            // Im folgenden zweiten Teil des Vorlaufalgorithmus werden alle noch freien Einträge 
            // des Arrays s belegt.Eingetragen wird zunächst überall die Anfangsposition des breitesten 
            // Randes des Musters, diese ist j = f[0].Ab Position i = j wird auf den nächstschmaleren 
            // Rand f[j] umgeschaltet usw.

            // Fall 2 
            for (int i = 0; i < pattern.Length; i++)
            {
                int j = f[0];

                if (s[i] == 0)
                {
                     s[i] = j;
                }

                if (i == j)
                    j = f[j];
            }


            // Ausgabe

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write("j");
            for (int k = 0; k < pattern.Length + 1; k++)
            {
                System.Console.Write("\t" + k);
            }

            System.Console.WriteLine();
            System.Console.Write("p[j]");
            for (int k = 0; k < pattern.Length; k++)
            {
                System.Console.Write("\t" + p[k]);
            }

            System.Console.WriteLine();
            System.Console.Write("f[j]");
            for (int k = 0; k < pattern.Length + 1; k++)
            {
                System.Console.Write("\t" + f[k]);
            }


            System.Console.WriteLine();
            System.Console.Write("s[j]");
            for (int k = 0; k < pattern.Length + 1; k++)
            {
                System.Console.Write("\t" + s[k]);
            }


        }

        public static void Example(string pattern, BoyerMooreSearch bm)
        {

            // Berechnung der Distanztabelle D nach Musteraufgaben
            var chars = pattern.ToCharArray();

            System.Console.Write("j");
            for (int i = 0; i < chars.Length; i++)
            {
                System.Console.Write("\t" + i);
            }
            System.Console.WriteLine();

            System.Console.Write("p[j]");
            for (int i = 0; i < chars.Length; i++)
            {
                System.Console.Write("\t" + chars[i]);
            }
            System.Console.WriteLine();

            System.Console.Write("occ()");
            var occ = new int[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                occ[i] = bm.GetOccurence(pattern, chars[i]);

                System.Console.Write("\t" + occ[i]);
            }
            System.Console.WriteLine();

            System.Console.Write("shift");
            var shift = new int[256];
            for (int i = 0; i < chars.Length; i++)
            {
                shift[i] = -1;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                shift[chars[i]] = chars.Length - occ[i] - 1;
                System.Console.Write("\t" + shift[chars[i]]);
            }
            for (int i = 0; i < shift.Length; i++)
            {
                if (shift[i] == -1)
                    shift[i] = pattern.Length;
            }
        }
    }

    public class BoyerMooreSearch 
    {
        private int[] _s = null;
        private int[] _occ = null;

        public void Search(string pattern, string text)
        {
            int n = text.Length;
            int m = pattern.Length;

            var t = text.ToCharArray();
            var p = pattern.ToCharArray();

            int i = 0;
            int j = 0;

            System.Console.WriteLine();
            System.Console.WriteLine(text);

            while (i <= n - m)
            {

                for (int k = 0; k < i; k++)
                    System.Console.Write(" ");
                System.Console.Write(pattern);

                j = m - 1;
                while (j >= 0 && p[j] == t[i + j]) 
                    j--;
                if (j < 0)
                {
                    System.Console.Write(" -= Found at: " + i + " =-"); //report(i);
                    i += _s[0];
                }
                else
                    i += Math.Max(_s[j + 1], j - _occ[t[i + j]]);
                
                System.Console.WriteLine();
            }
        }

        public int GetOccurence(string pattern, char c) {

            var chars = pattern.ToCharArray();

            int pos = -1;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == c)
                    pos = i;
            }

            return pos;
        }

        public void InitOcc(string pattern)
        {
            var p = pattern.ToCharArray();

            int j;
            char a;

            _occ = new int[256];

            for (a = (char)0; a < (char)256; a++)
                _occ[a] = -1;

            for (j = 0; j < pattern.Length; j++)
            {
                a = pattern[j];
                _occ[a] = j;
            }
        }

        public void Preprocessing(string pattern) {
            
            int i = pattern.Length;
            int j = pattern.Length + 1;
            char[] p = pattern.ToCharArray();

            int[] f = new int[pattern.Length+1];
            _s = new int[pattern.Length + 1];

            // Fall 1
            f[i] = j; // letzte Stelle auf m+1

            while (i > 0) // Index i auf dem Array f 
            {
                while (j < pattern.Length+1 && p[i-1] != p[j-1]) // Rand lässt sich nicht nach links fortsetzen 
                {
                    if (_s[j] == 0) // noch kein Eintrag 
                    {
                        _s[j] = j - i; 
                    }
                    j = f[j];
                }
                i--;
                j--;
                f[i] = j;
            }

            //System.Console.WriteLine();
            //System.Console.WriteLine();
            //System.Console.Write("j");
            //for (int k = 0; k < pattern.Length + 1; k++)
            //{
            //    System.Console.Write("\t" + k);
            //}

            //System.Console.WriteLine();
            //System.Console.Write("p[j]");
            //for (int k = 0; k < pattern.Length; k++)
            //{
            //    System.Console.Write("\t" + p[k]);
            //}

            //System.Console.WriteLine();
            //System.Console.Write("f[j]");
            //for (int k = 0; k < pattern.Length + 1; k++)
            //{
            //    System.Console.Write("\t" + f[k]);
            //}


            //System.Console.WriteLine();
            //System.Console.Write("s[j]");
            //for (int k = 0; k < pattern.Length + 1; k++)
            //{
            //    System.Console.Write("\t" + s[k]);
            //}

            // Fall 2
            j = f[0];

            for (i = 0; i < pattern.Length+1; i++)
            {
                if (_s[i] == 0)
                    _s[i] = j;
                if (i == j)
                    j = f[j];
            }


            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write("j");
            for (int k = 0; k < pattern.Length + 1; k++) 
            {
                System.Console.Write("\t" + k);
            }

            System.Console.WriteLine();
            System.Console.Write("p[j]");
            for (int k = 0; k < pattern.Length; k++)
            {
                System.Console.Write("\t" + p[k]);
            }

            System.Console.WriteLine();
            System.Console.Write("f[j]");
            for (int k = 0; k < pattern.Length + 1; k++)
            {
                System.Console.Write("\t" + f[k]);
            }


            System.Console.WriteLine();
            System.Console.Write("s[j]");
            for (int k = 0; k < pattern.Length + 1; k++)
            {
                System.Console.Write("\t" + _s[k]);
            }
        }
    }
}
