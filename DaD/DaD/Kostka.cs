using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DaD
{
    class Kostka
    {
        public int pocetStran;

        public Kostka(int _pocetStran)
        {
            pocetStran = _pocetStran;
        }

        public int Hod()
        {
            Random rnd = new Random();
            Thread.Sleep(100);
            int hozen_cislo = rnd.Next(1,pocetStran +1 );
            return hozen_cislo;
        }
    }
}
