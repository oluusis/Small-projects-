using System;
using System.Collections.Generic;
using System.Text;

namespace Pisemka5_2A_Hruban
{
    class Zlocinec
    {
        public string jmeno;
        protected bool zaMrizemi;

        public Zlocinec(string jmeno, bool zaMrizemi)
        {
            this.jmeno = jmeno;
            this.zaMrizemi = zaMrizemi;
        }

        public virtual void PachejZlocin()
        {
            if (zaMrizemi)
            {
                Console.WriteLine($"{jmeno} je zavřený v kriminále a nic spáchat nemůže");
            }
            else
            {
                Console.WriteLine($"{jmeno} spáchal zločin");
            }
        }
    }
}
