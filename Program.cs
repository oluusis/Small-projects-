using System;

namespace MyslímSiČíslo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zkus uhádnout na jaké číslo myslím od 1 do 1000!");          
            Random rnd = new Random();

            
            int náhodnéČíslo = rnd.Next(1, 1000);
            Console.WriteLine(náhodnéČíslo);
            int číslo = Convert.ToInt32(Console.ReadLine());


            while (číslo != náhodnéČíslo)
            {
                if ( číslo < náhodnéČíslo && číslo <= 1000)
                {
                    Console.WriteLine("Číslo je větší než " + číslo);
                }
                else if (číslo > náhodnéČíslo && číslo <= 1000)
                {
                    Console.WriteLine("Číslo je menší než " + číslo);
                }
                else
                {
                    Console.WriteLine("Číslo je mezi 1 - 1000");
                }
                číslo = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("Uhodl jsi číslo!");
            Console.ReadKey();

        }
    }
}
