using System;

namespace bankomat
{
    class Program
    {
        int učet = 0;
        static void Main(string[] args)
        {

            int zadejte_číslo = 0;
            int cislo = 0;

            Program ucet1 = new Program();

            do
            {
                Console.Clear();
                Console.WriteLine("Bankomat [v1.0] \n");
                Console.Write("1) vložit peníze \n2) Vybrat peníze\n3) Zůstatek na účtu\n4) Vypnout\n");
                Console.Write("\nVolba: ");
                zadejte_číslo = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                
                Console.WriteLine("Bankomat [v1.0] \n");
                if (zadejte_číslo == 1)
                {
                    Console.Write("Vkládaná časka [Kč]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    ucet1.učet += Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nVklad proběhl úspěšně!");
                    ucet1.zustatek();
                }
                else if (zadejte_číslo == 2)
                {
                    Console.Write("Vkládaná časka [Kč]: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    cislo = Convert.ToInt32(Console.ReadLine());
                    if(cislo > ucet1.učet)
                    {
                        Console.WriteLine("\nNemáte dostatek peněz na takový výběr!");
                        ucet1.zustatek();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        ucet1.učet -= cislo;
                        Console.WriteLine("\nVýběr proběhl úspěšně!");
                        ucet1.zustatek();
                    }                      
                }
                else if (zadejte_číslo == 3)
                {
                    Console.Write("Vkládaná časka [Kč]: \n");
                    ucet1.zustatek();
                }
            }
            while (zadejte_číslo != 4);           
        }
        public void zustatek()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Zůstatek na účtu: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(učet + "Kč");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();          
        }
    }
}
