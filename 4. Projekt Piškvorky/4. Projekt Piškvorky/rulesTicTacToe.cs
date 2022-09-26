using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace _4._Projekt_Piškvorky
{
    internal class rulesTicTacToe
    {
        protected string[,] map;
        protected int kurzorPozitionX;
        protected int kurzorPozitionY;
        protected string? player;
        public int move;

        public rulesTicTacToe(int mapSize)
        {
            this.map = new string[mapSize, mapSize];
            this.kurzorPozitionX = 3;
            this.kurzorPozitionY = 3;
        }

        public bool wintConstrolRowsAdnColumns()
        {
            int countRows = 0;
            int countColumns = 0;
            int countDiagonalLeft = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j + 1 != map.GetLength(1) && map[i, j] == map[i, j + 1] && map[i, j] != "   ")
                    {
                        countRows++;
                    }
                    else
                    {
                        countRows = 0;
                    }

                    if (j + 1 != map.GetLength(0) && map[j, i] == map[j + 1, i] && map[j, i] != "   ")
                    {
                        countColumns++;
                       
                    }
                    else
                    {
                        countColumns = 0;
                    }

                    if (countColumns == 4 || countRows == 4 || countDiagonalLeft == 4)
                    {
                        Console.WriteLine((player == " X ") ? "Crosses won!" : "Circles won!");
                        return true;
                    }
                }

            }

            return false;
        }

        public bool winDiagonalLeft()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map.GetLength(1) - 5 >= i && j + 4 >= 0)
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            if (j + l >= 10 || map[j + l, i + l] != player)
                            {
                                break;
                            }
                            if (l == 4)
                            {
                                Console.WriteLine((player == " X ") ? "Crosses won!" : "Circles won!");
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool winDiagonaRight()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map.GetLength(1) - 5 >= i && j - 4 >= 0)
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            if (map[i + l, j - l] != player)
                            {
                                break;
                            }
                            
                            if (l == 4)
                            {
                                Console.WriteLine((player == " X ") ? "Crosses won!" : "Circles won!");
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


        public void mapGeneration()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "   ";
                }
            }
        }

        public void writeMap()
        {
            for (int i = 0; i < map.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {

                    if (kurzorPozitionY == i && kurzorPozitionX == j || kurzorPozitionY + 1 == i && kurzorPozitionX == j)   // vybarvy pomoci pozice kurzoru +---+
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("+---+");
                    }
                    else if (kurzorPozitionY == i && kurzorPozitionX > j || kurzorPozitionY + 1 == i && kurzorPozitionX > j)
                    {
                        Console.Write("+---");
                    }
                    else if (kurzorPozitionY == i && kurzorPozitionX < j || kurzorPozitionY + 1 == i && kurzorPozitionX < j)
                    {
                        Console.Write("---+"); 
                    }
                    else if (j == 0)
                    {
                        Console.Write("+---+");
                    }
                    else
                    {
                        Console.Write("---+");
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();

                if (map.GetLength(0) == i)
                {
                    break;
                }

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (kurzorPozitionY == i && kurzorPozitionX == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write($"|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($"{map[i, j]}");

                    if (kurzorPozitionY == i && kurzorPozitionX == j || kurzorPozitionY == i && kurzorPozitionX - 1 == j) // vybarvy pomoci pozice kurzoru   | |
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"|");
                    }
                    else
                    {
                        Console.Write($"|");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
        public void writeIn()
        {
            move++;
            if (move % 2 == 0)
            {
                map[kurzorPozitionY, kurzorPozitionX] = " O ";

            }
            else
            {
                map[kurzorPozitionY, kurzorPozitionX] = " X ";
            }
            player = map[kurzorPozitionY, kurzorPozitionX];

        }

        public void moveKurzorPosition()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (kurzorPozitionY > 0)
                    {
                        kurzorPozitionY--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (kurzorPozitionY < map.GetLongLength(0) - 1)
                    {
                        kurzorPozitionY++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (kurzorPozitionX > 0)
                    {
                        kurzorPozitionX--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (kurzorPozitionX < map.GetLongLength(1) - 1)
                    {
                        kurzorPozitionX++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (map[kurzorPozitionY, kurzorPozitionX] == " X " || map[kurzorPozitionY, kurzorPozitionX] == " O ")
                    {
                        moveKurzorPosition();
                    }
                    else
                    {
                        writeIn();
                    }
                    break;
            }
            Console.Clear();
        }
    }
}
