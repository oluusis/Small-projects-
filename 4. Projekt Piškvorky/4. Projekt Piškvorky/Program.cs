using System.Xml;

namespace _4._Projekt_Piškvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int chooseGame = menu.selectGame();
            int size = menu.mapSize;

            rulesTicTacToe game1 = new rulesTicTacToe(size);
            while (true)
            {
              
                game1.mapGeneration();
                switch (chooseGame)
                {
                    case 0:
                        while (true)
                        {                         
                            if (game1.wintConstrolRowsAdnColumns() || game1.winDiagonalLeft() || game1.winDiagonaRight())
                            {
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            game1.writeMap();
                            game1.moveKurzorPosition();
                        }
                        break;
                    case 1:
                        Console.WriteLine("Work in progress...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        menu.menuAbout();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                if (chooseGame == 3)
                {
                    Console.WriteLine("\nBYE! Come again.");
                    break;
                }
                chooseGame = menu.selectGame();
                size = menu.mapSize;
                game1 = new rulesTicTacToe(size);
            }

        }
    }
}