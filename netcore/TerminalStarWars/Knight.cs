using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Knight : Jedi
    {
        public void Meditate(List<Trooper> trooperList)
        {
            if (trooperList.Count == 0)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Console.WriteLine("...Meditating...");
                Intelligence += 5; 
                Health += 10;
                Console.WriteLine("Intelligence increased by 5");
                Console.WriteLine("Health increased by 10");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public void ThrowLightsaber(Trooper enemy)
        {
            if (enemy == null || enemy.Health < 1)
            {
                Console.WriteLine("Attack Failed");
            }
            else
            {
                int damage = (Intelligence * 2) + Dexterity;
                Console.WriteLine($"...Attacking {enemy.Name} by throwing lightsaber ");
                enemy.Health -= damage; 
                Console.WriteLine($"Dealt {damage} damage");
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
                "Meditate",
                "Throw Lightsaber",
            };
            return actionList;
        }
        public Knight(string name) : base(name)
        {
            Health = 150;
            Strength = 5;
            Dexterity = 10;
        }
    }
}