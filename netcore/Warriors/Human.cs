using System;

namespace Warriors
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;
        public Human(string name, int str = 3, int intl = 3, int dex = 3, int hlth = 100)
        {
            Name = name;
            Strength = str;
            Intelligence = intl;
            Dexterity = dex;
            Health = hlth;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}, Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}");
        }
        public void Attack(Human enemy)
        {
            if (enemy == null)
            {
                System.Console.WriteLine("Failed Attack");
            }
            else 
            {
                int damage = 5 * Strength;
                Console.WriteLine($"...Attacking {enemy.Name}...");
                Console.WriteLine($"Dealt {damage} damage");
                enemy.Health -= damage;
            }
        }
    }
    public class Wizard : Human 
    {
        public void Heal()
        {
            Health += 10 * Intelligence;
        }
        public void FireBall(Human enemy)
        {
            Random rand = new Random();
            if (enemy == null)
            {
                Console.WriteLine("Fire Ball Failed");
            }
            else 
            {
                int damage = rand.Next(20, 51);
                Console.WriteLine($"...Casting Fire Ball on {enemy.Name}...");
                Console.WriteLine($"Dealt {damage} damage");
                enemy.Health -= damage;
            }
        }
        public Wizard(string name, int str = 3, int dex = 3) : base(name, str, 25, dex, 50)
        {
        }   
    }
    public class Ninja : Human
    {
        public void Steal(Human enemy)
        {
            Attack(enemy);
            Health += 10;

        }
        public void Retreat()
        {
            Health -= 15;
        }
        public Ninja(string name, int str = 3, int intl = 3, int hlth = 100) : base(name, str, intl, 175, hlth)
        {
        }
    }
    public class Samurai : Human 
    {
        public void DeathBlow(Human enemy)
        {
            if (enemy == null)
            {
                Console.WriteLine("Death Blow Failed");
            }
            else if (enemy != null && enemy.Health >= 50)
            {
                Attack(enemy);
            }
            else if (enemy != null && enemy.Health < 50)
            {
                enemy.Health = 0;
                Console.WriteLine($"You have vanquished {enemy.Name}");
            }
        }
        public void Meditate()
        {
            if (Health < 200)
            {
                Console.WriteLine("...Meditating...");
                Health = 200;
                Console.WriteLine("Maximum health restored");
            }
            else 
            {
                Console.WriteLine("You are already at full health");
            }
        }
        public Samurai(string name, int str = 3, int intl = 3, int dex = 3) : base(name, str, intl, dex, 200)
        {
        }
    }
}