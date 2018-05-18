using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Battle
    {
      public static void startFight(Warrior warrior1, Warrior warrior2)
        {
            bool eof=true;
            while (true)
            {
                eof = GetAttackResult(warrior1, warrior2);
                if (eof)
                    break;
                eof = GetAttackResult(warrior2, warrior1);
                if (eof)
                    break;
            }
        } 
       private static bool GetAttackResult(Warrior warriorToAttack, Warrior warriorToDefend)
        {
            int attack = warriorToAttack.Attack() - warriorToDefend.Block();
            int hp = warriorToDefend.Hurt(attack);
            if (hp != 0)
            {
                Console.WriteLine(warriorToAttack.Name + " attacks " + warriorToDefend.Name + " and deals " + attack + " damage" +
                    "\n" + warriorToDefend.Name + " has " + hp + " health.");
                return false;
            }
            else
            {
                Console.WriteLine(warriorToDefend.Name + " has died and " + warriorToAttack.Name + " is victorious." +
                    "\nGame is over.");
                return true;
            }
        }
    }
}
