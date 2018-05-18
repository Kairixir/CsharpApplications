using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior bob = new Warrior("Bob", 1000, 120, 40);
            Warrior pat = new Warrior("Pat", 1000, 120, 40);
            Battle.startFight(bob, pat);
            Console.ReadKey();

        }
    }
}
