using System;
using OOPHuman.Classes;

namespace OOPHuman
{
    class Program
    {
        static void Main(string[] args)
        {
            Human humanOne = new Human("Rothbar");
            Human humanTwo = new Human("Balthazar", 4, 3, 5, 115);
            humanOne.DisplayStats();
            humanTwo.DisplayStats();
            humanOne.Attack(humanTwo);
            humanTwo.DisplayStats();
            
        }
    }
}
