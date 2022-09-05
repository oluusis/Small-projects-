using System;
using System.Collections.Generic;
using System.Text;

namespace Pisemka5_2A_Hruban
{
    class MasovyVrah: Vrah
    {
        public MasovyVrah(string jmeno, bool zaMrizemi, int pocetObeti) : base(jmeno,zaMrizemi,pocetObeti)
        {
        }

        public override void PachejZlocin()
        {
            base.PachejZlocin();
        }

        public void Zavrazdi(int kolik)
        {
            if (zaMrizemi)
            {
                Console.WriteLine($"{jmeno} je zavřený v kriminále a nic spáchat nemůže");
            }
            else
            {
                pocetObeti += kolik;
                Console.WriteLine($"{jmeno} zavraždil {kolik} lidí a celkově již zbavil života {pocetObeti} lidí.");
            }
        }
    }
}
