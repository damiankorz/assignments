using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Trooper 
    {
        public string Name;
        public int Strength;
        public int Health;
        public Trooper()
        {
            Name = "Storm Trooper";
            Strength = 2;
            Health = 50;
        }
        public virtual void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine(" ");
        }
        public void Attack(Jedi hero)
        {
            if (hero == null || hero.Health < 1)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                int damage = Strength * 5;
                Console.WriteLine($"{Name} attacked {hero.Name} with blaster rifle");
                hero.Health -= damage;
                Console.WriteLine($"{Name} dealt {damage} damage");
                Console.WriteLine(" ");
                if (hero.Health > 0)
                {
                    Console.WriteLine($"{hero.Name} has {hero.Health} health remaining");
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} has benn eliminated from the battlefield");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}