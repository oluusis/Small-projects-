using System;
using System.Collections.Generic;
using System.Text;

namespace Pisemka5_2A_Hruban
{
    class Zlodej :Zlocinec
    {
        protected int ukradenyObnos;

        public Zlodej(int ukradenyObnos, string jmeno, bool zaMarizemi) : base(jmeno,zaMarizemi)
        {
            this.ukradenyObnos = ukradenyObnos;
        }

        public override void PachejZlocin()
        {
            base.PachejZlocin();
        }

        public void Ukradni(int kolik)
        {
            if (zaMrizemi)
            {
                Console.WriteLine($"{jmeno} je zavřený v kriminále a nic spáchat nemůže");
            }
            else
            {
                ukradenyObnos += kolik;
                Console.WriteLine($"{jmeno} už ukradl {kolik}, a celkově již odcizil majetek za {ukradenyObnos}");

            }
        }
    }
}
