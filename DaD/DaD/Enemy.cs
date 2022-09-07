using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaD
{
    class Enemy
    {
        public string jmeno;
        public int hp;
        public int maxHP;
        public int damage;
        public int xpForKill;

        public Enemy(string jmeno, int hp, int damage)
        {
            this.jmeno = jmeno;
            this.hp = hp;
            this.damage = damage;
            this.xpForKill = 10;
        }
        public void Vypsatzivoty()
        {
            Console.WriteLine($"Nestvůra {jmeno} má {hp} životů.");
        }
    }
}
