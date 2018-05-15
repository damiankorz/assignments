using System;

namespace TerminalStarWars
{
    public class Heavy : Trooper
    {
        public void SeismicCharge(Jedi hero)
        {
            if (hero == null || hero.Health < 1)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Random rand = new Random();
                int damage = rand.Next(25, 46);
                Console.WriteLine($"{Name} attacked {hero.Name} with seismic charge");
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
        public void BlasterCannon(Jedi hero)
        {
            int damage = Strength * 4;
            Console.WriteLine($"{Name} attacked {hero.Name} with blaster cannon");
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
        public Heavy() : base()
        {
            Name = "Heavy Trooper";
            Strength = 10;
            Health = 125;
        }
    }
}