using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._Projekt_Piškvorky
{
    internal class Menu
    {
        private string[] menu = { " * GAME FOR 2 PLAYERS", " * PLAY VS BOT", " * ABOUT GAME", " * EXIT" };
        public int mapSize;

        public int selectGame()
        {           
            int select = 0;
            writeMenu(select);

            while (true)
            {
                var znak = Console.ReadKey().Key;
               
                if (znak == ConsoleKey.DownArrow)
                {
                    select++;
                }
                else if (znak == ConsoleKey.UpArrow)
                {
                    select--;
                }
                else if(znak == ConsoleKey.Enter)
                {
                    if(select == 0 || select == 1)
                    {
                        mapSizer();
                    }
                    return select;
                }

                if(select == -1)
                {
                    select = 3;
                }

                if(select == 4)
                {
                    select = 0;
                }

                Console.Clear();
                writeMenu(select);              
            }
        }

        public void writeMenu(int select)
        {
            writeLogo();

            for (int i = 0; i < menu.Length; i++)
            {
                if (select == i)
                {
                    menu[i] = menu[i].Replace("*", ">");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(menu[i]);
                    menu[i] = menu[i].Replace(">", "*");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(menu[i]);
                }
            }
        }

        public void writeLogo()
        {
            string[] tictactoeLogo = {
                                        " _   _      _             _             ",
                                        "| | (_)    | |           | |            ",
                                        "| |_ _  ___| |_ __ _  ___| |_ ___   ___ ",
                                        "| __| |/ __| __/ _` |/ __| __/ _ \\ / _ \\",
                                        "| |_| | (__| || (_| | (__| || (_) |  __/",
                                        " \\__|_|\\___|\\__\\__,_|\\___|\\__\\___/ \\___|"};

            foreach (var logo in tictactoeLogo)
            {
                Console.WriteLine(logo);
            }
            Console.WriteLine();
        }

        public void mapSizer()
        {
            int size = 0;
            while (size < 5 || size > 50 )
            {
                Console.Write("\nAssign size of map(5-50): ");
                size = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            this.mapSize = size;
        }

        public void menuAbout()
        {
            writeLogo();
            Console.WriteLine("\nInputs: Arrows - moving cursor \n\tEnter - place X or O\nProgram si made by: Oliver hruban 25.9.2022\nVersion: 1.0");
        }
    }
}
