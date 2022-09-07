using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaD
{
    class GeneratorPriser
    {
        public static void VytvorPriseru(Enemy enemy)
        {
            Random rnd = new Random();

            string[] jmena_nestvur = { "Harpyje", "Oliver", "Jožin", "Zbažin", "Shrek" };
            enemy.jmeno = jmena_nestvur[rnd.Next(0, jmena_nestvur.Length)];
            enemy.hp = rnd.Next(20, 81);
            enemy.maxHP = enemy.hp;
            enemy.damage = rnd.Next(10, 20);
            enemy.xpForKill = (enemy.maxHP + enemy.damage) / 3;
        }
    }
}
