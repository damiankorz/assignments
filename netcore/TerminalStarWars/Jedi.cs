using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Jedi
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;
        public Jedi(string name) 
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine(" ");
        }
        public virtual List<string> Actions()
        {
            List<string> actionList = new List<string>(){
                "Attack"
            };
            return actionList;
        }
        public void Attack(Trooper enemy)
        {
            if (enemy == null || enemy.Health < 1)
            {
                Console.WriteLine("Attack Failed");
                Console.WriteLine(" ");
            }
            else
            {
                int damage = Strength * 5;
                Console.WriteLine($"...Attacking {enemy.Name} with lightsaber...");
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
    }
}