using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    internal class LESS 
    {
        public void Nacti(string cesta )
        {
            try
            {
                StreamReader sr = new StreamReader(cesta);
                List<string> rows = new List<string>();

                int start = 0;

                while (!sr.EndOfStream)
                {
                    rows.Add(sr.ReadLine());
                }
                sr.Close();

                var key = ConsoleKey.UpArrow;
                Console.WriteLine(Path.GetFileName(cesta));
                while (key != ConsoleKey.Enter)
                {
                    Console.WriteLine( "\n___________________________________");
                    for (int i = start; (i < Console.WindowHeight + start) && i < rows.Count; i++)
                    {
                        Console.WriteLine(rows[i]);
                    }

                    Console.Write(":");
                    key = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (key)
                    {
                        case ConsoleKey.DownArrow:
                            if (start < rows.Count - Console.WindowHeight)
                            {
                                start++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (start > 0)
                            {
                                start--;
                            }
                            break;
                        case ConsoleKey.PageDown:
                            start = rows.Count - Console.WindowHeight;
                            break;

                        case ConsoleKey.PageUp:
                            start = 0;
                            break;
                    }
                }
                
            }
            catch {}    
        }
    }
}
