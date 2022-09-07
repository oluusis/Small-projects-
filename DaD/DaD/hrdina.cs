using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DaD
{
    class hrdina
    {
        public string jmeno;
        public string rasa;
        public bool isMale;
        public int hp;
        public int maxHP;
        public int damage;
        public int level;
        public int xpForNextLevel;

        public hrdina(string jmeno, int hp, int damage)
        {
            this.jmeno = jmeno;
            this.rasa = "Člověk";
            this.isMale = true;
            this.hp = hp;
            this.maxHP = hp;
            this.damage = damage;
            this.level = 1;
            this.xpForNextLevel = 10;
        }

        public void Uder(Enemy enemy,Kostka kostka)
        {
            //Utok
            int random_damage = damage + kostka.Hod();
            enemy.hp = Math.Max(enemy.hp - random_damage, 0);
            Console.WriteLine($"Hrdina {jmeno} udeřil {enemy.jmeno} za {random_damage}.");
            if (enemy.hp > 0)
            {
                //Protiutok
                hp = Math.Max(enemy.hp - damage, 0);
                Console.WriteLine($"Nepřítel {enemy.jmeno} vratil úder {jmeno} za {enemy.damage}.");
            }
            else
            {
                Console.WriteLine($"Nepřítel {enemy.jmeno} zemřel.");
            }
        }

        public void Vypsatzivoty()
        {
            Console.WriteLine($"{jmeno} má {hp} životů." );
        }

        public void LevelUp()
        {
            level ++;
            maxHP += 10;
            hp += 10;
            damage += 3;
            xpForNextLevel = 10 * level;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hrdina {jmeno} postoupil na další uroveň.");
            Console.ResetColor();
        } 
    }

   
}
