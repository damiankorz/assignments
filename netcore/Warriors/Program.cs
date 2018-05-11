using System;

namespace Warriors
{
    class Program
    {
        static void Main(string[] args)
        {
            Human humanOne = new Human("Aragorn");
            Wizard wizardOne = new Wizard("Gandalf");
            Ninja ninjaOne = new Ninja("Raizo");
            Samurai samuraiOne = new Samurai("Katsumoto");
            humanOne.DisplayStats();
            wizardOne.DisplayStats();
            ninjaOne.DisplayStats();
            samuraiOne.DisplayStats();
        }
    }
}
