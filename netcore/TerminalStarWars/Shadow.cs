using System; 
using System.Collections.Generic;

namespace TerminalStarWars
{
    public class Shadow : Trooper
    {
        public void RegenerationField(List<Jedi> jediList)
        {
            if (jediList.Count == 0)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Console.WriteLine($"{Name} deployed regeneration field");
                Health += 15;
                Console.WriteLine($"{Name}'s health increased by 15");
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
        public void ShadowShot(Jedi hero)
        {
            if (hero == null || hero.Health < 1)
            {
                Console.WriteLine($"{Name}'s attack failed");
                Console.WriteLine(" ");
            }
            else 
            {
                Random rand = new Random();
                int damage = rand.Next(35, 55);
                Console.WriteLine($"{Name} is attacking...");
                Console.WriteLine($"{Name} attacked {hero.Name} with shadow shot");
                hero.Health -= damage;
                Console.WriteLine($"{Name} dealt {damage} health damage");
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
        public Shadow() : base()
        {
            Name = "Shadow Trooper";
            Health = 175;
            Strength = 5;
        }
    }
}