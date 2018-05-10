namespace OOPHuman.Classes
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
            System.Console.WriteLine($"Name: {Name}, Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}");
        }
        public void Attack(Human human)
        {
            int damage = 5 * Strength;
            System.Console.WriteLine($"...Attacking {human.Name}...");
            System.Console.WriteLine($"Dealt {damage} damage");
            human.Health -= damage;
        }
    }
}