using System;

namespace OOP___Hra_upgrated
{
    class Program
    {
        string[,] mapa1 =     {{"x ", "x ", "x ", "x ", "x ", "x ", "x ","x ","x ","x ","x ","x ",},
                               { "x ", "h ", "x ", "y ", "y ", "y ","y ","y ","y ","y ","y ","x ",},
                               { "x ", "y ", "x ", "y ", "x ", "y ","x ","x ","x ","x ","y ","x ",},
                               { "x ", "y ", "y ", "y ", "x ", "y ","y ","y ","x ","o ","y ","x ",},
                               { "x ", "x ", "y ", "x ", "x ", "x ","y ","x ","x ","x ","x ","x ",},
                               { "x ", "o ", "y ", "x ", "o ", "y ","y ","x ","o ","y ","y ","x ",},
                               { "x ", "x ", "x ", "x ", "x ", "x ","y ","x ","x ","x ","y ","x ",},
                               { "x ", "x ", "y ", "e ", "y ", "y ","y ","y ","y ","x ","y ","x ",},
                               { "x ", "y ", "y ", "x ", "x ", "y ","x ","x ","y ","y ","y ","c ",},
                               { "x ", "y ", "x ", "x ", "y ", "y ","y ","x ","x ","x ","y ","x ",},
                               { "x ", "o ", "x ", "o ", "y ", "x ","y ","y ","o ","x ","o ","x ",},
                               {"x ", "x ", "x ", "x ", "x ", "x ", "x ","x ","x ","x ","x ","x ",}};

        string[,] mapa2 =     {{"x ", "x ", "x ", "x ", "x ", "x ", "x ","x ","x ","x ","x ","x ",},
                               { "x ", "y ", "y ", "y ", "y ", "y ","y ","o ","x ","y ","o ","x ",},
                               { "x ", "y ", "x ", "x ", "y ", "x ","y ","x ","x ","y ","x ","x ",},
                               { "x ", "y ", "y ", "x ", "o ", "x ","y ","y ","y ","y ","y ","x ",},
                               { "x ", "x ", "y ", "x ", "x ", "x ","x ","x ","x ","x ","y ","x ",},
                               { "x ", "y ", "y ", "y ", "x ", "o ","y ","y ","y ","y ","y ","x ",},
                               { "x ", "o ", "x ", "y ", "x ", "x ","y ","x ","x ","x ","x ","x ",},
                               { "x ", "x ", "x ", "y ", "x ", "y ","y ","y ","y ","x ","o ","x ",},
                               { "h ", "y ", "x ", "y ", "x ", "x ","e ","x ","y ","y ","y ","x ",},
                               { "x ", "y ", "x ", "y ", "x ", "y ","y ","x ","x ","x ","y ","x ",},
                               { "x ", "y ", "y ", "y ", "x ", "y ","y ","y ","o ","x ","o ","x ",},
                               {"x ", "x ", "x ", "x ", "x ", "c ", "x ","x ","x ","x ","x ","x ",}};

        string[,] mapa3 =     {{"x ", "x ", "x ", "x ", "x ", "h ", "x ","x ","x ","x ","x ","x ",},
                               { "x ", "y ", "y ", "o ", "x ", "y ","x ","o ","y ","y ","o ","x ",},
                               { "x ", "y ", "x ", "x ", "x ", "y ","x ","x ","y ","x ","x ","x ",},
                               { "x ", "y ", "y ", "x ", "y ", "y ","y ","y ","y ","y ","o ","x ",},
                               { "c ", "y ", "o ", "x ", "e ", "x ","x ","x ","x ","y ","x ","x ",},
                               { "x ", "y ", "x ", "x ", "y ", "y ","o ","x ","y ","y ","y ","x ",},
                               { "x ", "y ", "y ", "x ", "y ", "x ","x ","x ","y ","x ","o ","x ",},
                               { "x ", "x ", "y ", "x ", "y ", "y ","y ","y ","y ","x ","x ","x ",},
                               { "x ", "y ", "y ", "x ", "x ", "y ","x ","x ","y ","x ","o ","x ",},
                               { "x ", "y ", "x ", "x ", "y ", "y ","y ","x ","y ","x ","y ","x ",},
                               { "x ", "y ", "y ", "y ", "y ", "x ","y ","y ","y ","y ","y ","x ",},
                               {"x ", "x ", "x ", "x ", "x ", "x ", "x ","x ","x ","x ","x ","x ",}};


        public int poziceX = 1;
        public int poziceY = 1;
        public int poziceXEnemy = 7;
        public int poziceYEnemy = 3;
        public int respown_X = 1;
        public int respown_Y = 1;
        public bool postupNahoru;


        /// <summary>
        /// Vypíše mapu na základě písmen
        /// </summary>
        public void vypis_mapu()
        {
            for (int i = 0; i < mapa1.GetLength(0); i++)
            {
                for (int j = 0; j < mapa1.GetLength(1); j++)
                {
                    if (mapa1[i, j] == "x ")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (mapa1[i, j] == "y ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    else if (mapa1[i, j] == "h ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (mapa1[i, j] == "o ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    else if (mapa1[i, j] == "e ")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (mapa1[i, j] == "c ")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(mapa1[i, j]);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void pohyb()
        {         
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    
                    if(mapa1[poziceX - 1, poziceY] == "e ")
                    {
                        respown();
                        break;
                    }
                    if (mapa1[poziceX - 1, poziceY] == "x " || (mapa1[poziceX - 1, poziceY] == "c " && počítání_mincí != 0) )
                    {
                        break;
                    }
                    else
                    {
                        mapa1[poziceX, poziceY] = "y ";
                        mapa1[poziceX - 1, poziceY] = "h ";
                        poziceX -= 1;
                    }
                    break;

                case ConsoleKey.S:

                    if (mapa1[poziceX + 1, poziceY] == "e ")
                    {
                        respown();
                        break;
                    }
                    if (mapa1[poziceX + 1, poziceY] == "x " ||(mapa1[poziceX + 1, poziceY] == "c " && počítání_mincí != 0))
                    {
                        break;
                    }
                    else
                    {
                        mapa1[poziceX, poziceY] = "y ";
                        mapa1[poziceX + 1, poziceY] = "h ";
                        poziceX += 1;
                    }
                    break;

                case ConsoleKey.A:

                    if (mapa1[poziceX, poziceY - 1] == "e ")
                    {
                        respown();
                        break;
                    }
                    if (mapa1[poziceX, poziceY - 1] == "x "||(mapa1[poziceX , poziceY -1] == "c " && počítání_mincí != 0))
                    {
                        break;
                    }
                    else
                    {
                        mapa1[poziceX, poziceY] = "y ";
                        mapa1[poziceX, poziceY - 1] = "h ";
                        poziceY -= 1;
                    }
                    break;

                case ConsoleKey.D:
                   
                    if (mapa1[poziceX, poziceY+1] == "e ")
                    {
                        respown();
                        break;
                    }
                    if (mapa1[poziceX, poziceY+1] == "x " || (mapa1[poziceX , poziceY +1] == "c " && počítání_mincí != 0))
                    {
                        break;
                    }
                    else
                    {
                        mapa1[poziceX, poziceY] = "y ";
                        mapa1[poziceX, poziceY + 1] = "h ";
                        poziceY += 1;
                    }
                    break;
            }
        }
       
        public void respown()
        {
            mapa1[respown_X, respown_Y] = "h ";
            mapa1[poziceX, poziceY] = "y ";
            poziceX = respown_X;
            poziceY = respown_Y;         
        }
      
        public int posun = 1;
        public void pohybEnemyDoStrany()
        {
            if (mapa1[poziceXEnemy,poziceYEnemy + posun] == "x ")
            {
                posun = posun * (-1);
            }
            if(mapa1[poziceXEnemy, poziceYEnemy + posun] == "h ")
            {
                respown();
            }
            mapa1[poziceXEnemy, poziceYEnemy] = "y ";
            poziceYEnemy = poziceYEnemy + posun;
            mapa1[poziceXEnemy, poziceYEnemy] = "e ";

        }
        public void pohybEnemyNahoru()
        {
            if (mapa1[poziceXEnemy + posun, poziceYEnemy ] == "x ")
            {
                posun = posun * (-1);
            }
            if (mapa1[poziceXEnemy + posun, poziceYEnemy ] == "h ")
            {
                respown();
            }

            mapa1[poziceXEnemy, poziceYEnemy] = "y ";
            poziceXEnemy = poziceXEnemy + posun;
            mapa1[poziceXEnemy, poziceYEnemy] = "e ";

        }

        public int počítání_mincí;
        public int count = 0;
        public int opakovaní;
        public int počítaníMap = 1;


        public int spočitej_poceMinci()
        {
            for (int i = 0; i < mapa1.GetLength(0); i++)
            {
                for (int j = 0; j < mapa1.GetLength(1); j++)
                {
                    if (mapa1[i,j] == "o ")
                    {
                        počítání_mincí++;
                    }
                }
            }
            count++;
            if (count == 1)
            {
                opakovaní = počítání_mincí;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Počet potřebných minchích: " + (opakovaní-počítání_mincí) + "/" + opakovaní);
            return počítání_mincí;
        }
        public void změn_mapu(int x, int y, int xEnemy, int yEnemy, bool nahoru, string[,] mapa)
        {
            mapa1 = mapa;
            poziceX = x;
            poziceY = y;
            respown_X = x;
            respown_Y = y;
            poziceXEnemy = xEnemy;
            poziceYEnemy = yEnemy;
            postupNahoru = nahoru;
            počítání_mincí = 0;
            count = 0;
            opakovaní = 0;
            počítaníMap += 1;
        }
        static void Main(string[] args)
        {
            Program objekt1 = new Program();
            string[,] mapa1 = objekt1.mapa1;
            string[,] mapa2 = objekt1.mapa2;
            string[,] mapa3 = objekt1.mapa3;
            int pocetKroku = 0;
            
            while (objekt1.počítání_mincí == 0 && mapa3[4,0] != "h ")
            {
                pocetKroku++;
                objekt1.spočitej_poceMinci();              
                objekt1.vypis_mapu();
                objekt1.pohyb();
                if (objekt1.počítaníMap == 1 )
                {
                    objekt1.pohybEnemyDoStrany();
                }
                else if (objekt1.počítaníMap == 2)
                {
                    objekt1.pohybEnemyNahoru();
                }
                else if ( objekt1.počítaníMap == 3) 
                {
                    objekt1.pohybEnemyNahoru();
                }
                           
                if (objekt1.poziceX == objekt1.poziceXEnemy && objekt1.poziceY == objekt1.poziceYEnemy)
                {
                    objekt1.respown();
                }

                Console.Clear();
               
                if (mapa1[8, 11] == "h " && objekt1.počítání_mincí == 0)
                {
                    mapa1[8, 11] = "y ";
                    objekt1.změn_mapu(8,0,8,6,false,mapa2);
                }
                else if (mapa2[11, 5] == "h " && objekt1.počítání_mincí == 0)
                {
                    mapa2[11, 5] = "y ";
                    objekt1.změn_mapu(0,5,4,4,true,mapa3);
                }
                objekt1.počítání_mincí = 0;   
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Dohrál jsi hru za: " + pocetKroku + "kroků.");
            Console.ReadKey();

        }
    }

}
