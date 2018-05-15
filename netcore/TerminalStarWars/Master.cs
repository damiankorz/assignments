using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Master : Jedi
    {
        public void Heal(List<Trooper> trooperList)
        {
            if (trooperList.Count == 0)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else if (Health < 200 && trooperList.Count > 0)
            {
                Console.WriteLine("...Healing...");
                Health = 200;
                Console.WriteLine("Maximum health restored");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            else if (Health == 200 && trooperList.Count > 0)
            {
                Console.WriteLine("You are already at full health");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public void ForceLightning(Trooper enemy)
        {
            if (enemy == null || enemy.Health < 1)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else if (enemy != null && enemy.Health >= 50)
            {
                Console.WriteLine("Force lignthing failed. Enemy must have less that 50 health.");
                Attack(enemy);
                if (enemy.Health > 0)
                {
                    Console.WriteLine($"{enemy.Name} has {enemy.Health} health remaining");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} eliminated from the battlefield");
                }
            }
            else if (enemy != null && enemy.Health < 50)
            {
                Console.WriteLine($"...Attacking {enemy.Name} with force lighnting");
                enemy.Health = 0;
                Console.WriteLine($"The lightning consumed {enemy.Name}");
                Console.WriteLine(" ");
                if (enemy.Health > 0)
                {
                    Console.WriteLine($"{enemy.Name} has {enemy.Health} health remaining");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} eliminated from the battlefield");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public override List<string> Actions()
        {
            List<string> actionList = new List<string>(){
                "Attack",
                "Heal",
                "Force Lightning",
            };
            return actionList;
        }
        public Master(string name) : base(name)
        {
            Health = 200;
            Intelligence = 50;
            Strength = 8; 
            Dexterity = 20; 
        }
    }
}