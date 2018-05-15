using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Apprentice : Jedi
    {
        public void Focus(List<Trooper> trooperList)
        {
            if (trooperList.Count == 0)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Strength += 3;
                Console.WriteLine($"{Name}'s strength increased by 3");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public void ForcePush(Trooper enemy)
        {
            Random rand = new Random();
            if (enemy == null || enemy.Health < 1)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else 
            {
                int damage = rand.Next(10,25);
                Console.WriteLine($"...Attacking {enemy.Name} with force push... ");
                enemy.Health -= damage; 
                Console.WriteLine($"Dealt {damage} damage!");
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
                "Force Push",
                "Focus"
            };
            return actionList;
        }
        public Apprentice(string name) : base(name)
        {
            Health = 50;
            Intelligence = 5;
        }
    }
}