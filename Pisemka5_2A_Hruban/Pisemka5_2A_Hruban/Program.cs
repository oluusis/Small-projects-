using System;

namespace Pisemka5_2A_Hruban
{
    class Program
    {
        static void Main(string[] args)
        {

            Zlocinec zlocinec1 = new Zlocinec("Oliver", false);
            Vrah vrah1 = new Vrah("Kuba", false, 5);
            MasovyVrah vrahMasovy1 = new MasovyVrah("Tomas", true, 0);

            vrahMasovy1.Zavrazdi(5);
            vrahMasovy1.PachejZlocin();
        }
    }
}
