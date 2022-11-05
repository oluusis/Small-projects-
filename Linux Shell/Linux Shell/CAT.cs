using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class CAT
    {
        public void WriteFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                Console.WriteLine();
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
                sr.Close();
                Console.WriteLine();
            }
            catch (Exception ex)
            {}
           
        }
    }
}
