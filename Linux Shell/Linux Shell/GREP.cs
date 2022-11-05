using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class GREP
    {
        public void Nacti(string slovo, string cesta)
        {
            try
            {
                StreamReader sr = new StreamReader(cesta);
                int count = 0;
                Console.WriteLine($"Slovo \"{slovo}\":\n___________________\n");

                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    if (row.Contains(slovo))
                    {
                        Console.WriteLine(row);
                        count++;
                    }
                }
                sr.Close();
                Console.WriteLine("\nPočet výskytů: " + count + "\n___________________");
            }
            catch(Exception ex) 
            {
                //Console.WriteLine("Wrong syntax :(\n");
            }            
        }
    }
}
