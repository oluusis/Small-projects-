using System;

namespace DaD
{
    class Program
    {
        static void Main(string[] args)
        {
            Kostka kostka1 = new Kostka(6);
            hrdina hrac1 = new hrdina("Vojta",100,10);
            Enemy enemy1 = new Enemy("Harpyje", 17, 5);

            while(hrac1.hp != 0)
            {
                hrac1.Vypsatzivoty();
                enemy1.Vypsatzivoty();

                //Souboj
                while (enemy1.hp > 0 && hrac1.hp > 0)
                {

                    hrac1.Uder(enemy1, kostka1);
                    hrac1.Vypsatzivoty();
                    enemy1.Vypsatzivoty();

                }

                //Nárok na nový level
                hrac1.xpForNextLevel -= enemy1.xpForKill;
                if (hrac1.xpForNextLevel <= 0)
                {
                    hrac1.LevelUp();
                }

                Console.ReadKey();
                //Generování nové příšery
                GeneratorPriser.VytvorPriseru(enemy1);
            }
            Console.ReadKey();
        }
    }
}
