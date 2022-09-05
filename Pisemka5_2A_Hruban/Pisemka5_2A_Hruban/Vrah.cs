using System;
using System.Collections.Generic;
using System.Text;

namespace Pisemka5_2A_Hruban
{
    class Vrah : Zlocinec
    {
        protected int pocetObeti;
        
        public Vrah(string jmeno, bool zaMarizemi, int pocetObeti): base(jmeno,zaMarizemi)
        {
            this.pocetObeti = pocetObeti;
        }

        public override void PachejZlocin()
        {
            if (zaMrizemi)
            {
                Console.WriteLine($"{jmeno} je zavřený v kriminále a nic spáchat nemůže");
            }
            else
            {
                Console.WriteLine($"{jmeno} spáchal závažný zločin.");
            }
        }

        public void Zavrazdi(string koho)
        {
            if (zaMrizemi)
            {
                Console.WriteLine($"{jmeno} je zavřený v kriminále a nic spáchat nemůže");
            }
            else
            {
                pocetObeti++;
                Console.WriteLine($"{jmeno} zavraždil {koho} a celkově zabil {pocetObeti}");
            }
        }
    }
}
