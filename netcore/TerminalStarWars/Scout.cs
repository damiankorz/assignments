using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Scout : Trooper 
    {
        public int Precision; 
        public void ScoutField(List<Jedi> jediList)
        {
            if (jediList.Count == 0)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Console.WriteLine($"{Name} scouted the field");
                Precision += 10; 
                Console.WriteLine($"{Name}'s precision increased by 10");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public void PrecisionStrike(Jedi hero)
        {
            if (hero == null || hero.Health < 1)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                int damage = Precision * 2;
                Console.WriteLine($"{Name} attacked {hero.Name} with precision strike");
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
        public Scout() : base()
        {
            Name = "Scout Trooper";
            Health = 75; 
            Precision = 20;
        }
        public override void DisplayStats() 
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Precision: {Precision}");
            Console.WriteLine(" ");
        }
    }
}