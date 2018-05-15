using System;
using System.Collections.Generic;

namespace TerminalStarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Terminal Star Wars!");
            Console.WriteLine(" ");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            BaseGame();
        }
        // create user controlled team of jedi
        public static List<Jedi> CreateUserTeam()
        {
            Console.WriteLine("Name your Jedi Apprentice:");
            Apprentice apprentice = new Apprentice(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("Name your Jedi Knight");
            Knight knight = new Knight(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("Name your Jedi Master");
            Master master = new Master(Console.ReadLine());
            Console.WriteLine(" ");
            List<Jedi> jediList = new List<Jedi>(){
                apprentice,
                knight,
                master,
            };
            Console.WriteLine("Your team consists of ...");
            Console.WriteLine(" ");
            foreach (Jedi player in jediList)
            {
                player.DisplayStats();
                Console.WriteLine(" ");
            }
            return jediList;
        }
        // create computer controlled team of troopers
        public static List<Trooper> CreateOpponentTeam()
        {
            Scout scout = new Scout();
            Console.WriteLine($"Adding player {scout.Name}");
            Heavy heavy = new Heavy();
            Console.WriteLine($"Adding player {heavy.Name}");
            Shadow shadow = new Shadow();
            Console.WriteLine($"Adding player {shadow.Name}");
            List<Trooper> trooperList = new List<Trooper>(){
                scout,
                heavy,
                shadow,
            };
            Console.WriteLine(" ");
            Console.WriteLine("Enemy team consists of...");
            Console.WriteLine(" ");
            foreach (Trooper player in trooperList)
            {
                player.DisplayStats();
                Console.WriteLine(" ");
            }
            return  trooperList;
        }
        // create a system where the user selects an enemy to attack
        public static int UserEnemySelection(List<Trooper> trooperList)
        {
            Console.WriteLine("Enter the number of the enemy you want to attack");
                for (int i = 0; i < trooperList.Count; i++)
                {
                    Console.WriteLine($"{i} - {trooperList[i].Name}");
                }
                string enemyString = Console.ReadLine();
                int enemyInt = 0;
                if (enemyString == "0") {}
                if (enemyString == "1")
                {
                    enemyInt = 1;
                }
                if (enemyString == "2")
                {
                    enemyInt = 2;
                }
                return enemyInt;
        }
        // create a system where the user selects an action to perform
        public static string UserActionSelection(Jedi jedi)
        {
            Console.WriteLine($"It is {jedi.Name}'s turn...");
            Console.WriteLine(" ");
            jedi.DisplayStats();
            Console.WriteLine(" ");
            Console.WriteLine($"Enter the number of the action {jedi.Name} should use?");
            List<string> actionList = jedi.Actions();
            for (int i = 0; i < actionList.Count; i++)
            {
                Console.WriteLine($"{i} - {actionList[i]} ");
            }
            Console.WriteLine(" ");
            string inputAttack = Console.ReadLine();
            return inputAttack;
        }
        // create a system for a computer controlled return
        public static int[] ComputerTurn(Trooper trooper, List<Jedi> jediList)
        {
            Random rand = new Random();
            Console.WriteLine($"It is now {trooper.Name}'s turn...");
            Console.WriteLine(" ");
            trooper.DisplayStats();
            Console.WriteLine(" ");
            /* create a an array of length 2 with a player probability and action probability
            player probability will determine which jedi the computer will attack
            action probability will determine which action the computer will take */
            int playerProbability = rand.Next(0, jediList.Count);
            int actionProbability = rand.Next(0, 3);
            int[] probabilityArr = new int[2] {playerProbability, actionProbability};
            return probabilityArr;
        }
        // main system for game interaction 
        public static void BaseGame()
        {
            List<Jedi> jediList = CreateUserTeam();
            /* create an array from the created list
            the array will be used to cast the players on their respective turn
            the list will be used to remove eliminated players - will be used to see if game has ended */
            Jedi[] jediArr = jediList.ToArray();
            Console.WriteLine("Press enter to cotinue...");
            Console.ReadLine();
            List<Trooper> trooperList = CreateOpponentTeam();
            Trooper[] trooperArr = trooperList.ToArray();
            Console.WriteLine("Press enter to begin battle...");
            Console.ReadLine();
            Console.WriteLine("...Determing random player order...");
            Console.WriteLine(" ");
            int[] order = new int[6] {1,2,3,4,5,6};
            // shuffle array for random order
            Random rand = new Random();
            for (int i = 0; i < order.Length - 1; i++)
            {
                int randIdx = rand.Next(i+1, order.Length - 1);
                int temp = order[i];
                order[i] = order[randIdx];
                order[randIdx] = temp;
            }; 
            // check if the count in list of jedis and list of troopers are greater than zero 
            int idx = 0;
            if (jediList.Count > 0 && trooperList.Count > 0)
            {
                while (idx < order.Length)
                {
                    // if the count in jedi list is less than 1, game has ended, user has lost, prompt to begin new game
                    if (jediList.Count < 1)
                    {  
                        Console.WriteLine("You have fallen to the Galactic Empire");
                        Console.WriteLine("Game Over");
                        Console.WriteLine(" ");
                        Console.WriteLine("Do you want to play again? y/n");
                        string confirm = Console.ReadLine();
                        if (confirm == "")
                        {
                            return;
                        }
                        if (confirm == "y")
                        {
                            Console.WriteLine(" ");
                            BaseGame();
                        }
                        if (confirm == "n")
                        {
                            return;
                        }
                    }
                    // if the count in trooper list is less than 1, game has ended, user has won, prompt to begin new game
                    if (trooperList.Count < 1)
                    {  
                        Console.WriteLine("You have prevailed against the Galatic Empire!");
                        Console.WriteLine("Game Over");
                        Console.WriteLine(" ");
                        Console.WriteLine("Do you want to play again? y/n");
                        string confirm = Console.ReadLine();
                        if (confirm == "")
                        {
                            return;
                        }
                        if (confirm == "y")
                        {
                            Console.WriteLine(" ");
                            BaseGame();
                        }
                        if (confirm == "n")
                        {
                            return;
                        }
                    }
                    // jedi apprentice turn 
                    if (order[idx] == 1)
                    {
                        Apprentice apprentice = (Apprentice)jediArr[0];
                        if (apprentice.Health > 0 && trooperList.Count > 0)
                        {
                            string inputAttack = UserActionSelection(apprentice);
                            if (inputAttack == "0")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                apprentice.Attack(trooperList[enemyInt]);
                            }
                            if (inputAttack == "1")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                apprentice.ForcePush(trooperList[enemyInt]);

                            }
                            if (inputAttack == "2")
                            {
                                apprentice.Focus(trooperList);  
                            }
                        }
                        else 
                        {
                            jediList.Remove(apprentice);
                        }
                        if (idx == 5)
                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                    // jedi knight turn 
                    if (order[idx] == 2)
                    {
                        Knight knight = (Knight)jediArr[1];
                        if (knight.Health > 0 && trooperList.Count > 0)
                        {
                            string inputAttack = UserActionSelection(knight);
                            if (inputAttack == "0")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                knight.Attack(trooperList[enemyInt]);
                            }
                            if (inputAttack == "1")
                            {
                                knight.Meditate(trooperList);
                            }
                            if (inputAttack == "2")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                knight.ThrowLightsaber(trooperList[enemyInt]);
                            }
                        }
                        else 
                        {
                            jediList.Remove(knight);
                        }
                        if (idx == 5)

                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                    // jedi master turn 
                    if (order[idx] == 3)
                    {
                        Master master = (Master)jediArr[2];
                        if (master.Health > 0 && trooperList.Count > 0)
                        {
                            string inputAttack = UserActionSelection(master);
                            if (inputAttack == "0")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                master.Attack(trooperList[enemyInt]);
                            }
                            if (inputAttack == "1")
                            {
                                master.Heal(trooperList);
                            }
                            if (inputAttack == "2")
                            {
                                int enemyInt = UserEnemySelection(trooperList);
                                master.ForceLightning(trooperList[enemyInt]);
                            }
                        }
                        else
                        {
                            jediList.Remove(master);
                        }
                        if (idx == 5)
                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                    // scout trooper turn 
                    if (order[idx] == 4)
                    {
                        Scout scout = (Scout)trooperArr[0];
                        if (scout.Health > 0 && jediList.Count > 0)
                        {
                            int[] probabilityArr = ComputerTurn(scout, jediList);
                            if (probabilityArr[1] == 0)
                            {
                                scout.Attack(jediList[probabilityArr[0]]);
                            }
                            if (probabilityArr[1] == 1)
                            {
                                scout.ScoutField(jediList);
                            }
                            if (probabilityArr[1] == 2)
                            {
                                scout.PrecisionStrike(jediList[probabilityArr[0]]);
                            }
                        }
                        else {
                            trooperList.Remove(scout);  
                        }
                        if (idx == 5)
                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                    // heavy trooper turn
                    if (order[idx] == 5)
                    {
                        Heavy heavy = (Heavy)trooperArr[1];
                        if (heavy.Health > 0 && jediList.Count > 0)
                        {
                            int[] probabilityArr = ComputerTurn(heavy, jediList);
                            if (probabilityArr[1] == 0)
                            {
                                heavy.Attack(jediList[probabilityArr[0]]);
                            }
                            if (probabilityArr[1] == 1)
                            {
                                heavy.BlasterCannon(jediList[probabilityArr[0]]);
                            }
                            if (probabilityArr[1] == 2)
                            {
                                heavy.SeismicCharge(jediList[probabilityArr[0]]);
                            }
                        }
                        else 
                        {
                            trooperList.Remove(heavy);
                        }
                        if (idx == 5)
                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                    // shadow trooper turn 
                    if (order[idx] == 6)
                    {
                        Shadow shadow = (Shadow)trooperArr[2];
                        if (shadow.Health > 0 && jediList.Count > 0)
                        {
                            int[] probabilityArr = ComputerTurn(shadow, jediList);
                            if (probabilityArr[1] == 0)
                            {
                                shadow.Attack(jediList[probabilityArr[0]]);
                            }
                            if (probabilityArr[1] == 1)
                            {
                                shadow.RegenerationField(jediList);
                            }
                            if (probabilityArr[1] == 2)
                            {
                                shadow.ShadowShot(jediList[probabilityArr[0]]);
                            }
                        }
                        else 
                        {
                            trooperList.Remove(shadow);
                        }
                        if (idx == 5)
                        {
                            idx = 0;
                        }
                        else
                        {
                            idx++;
                        }
                    }
                }
            }
        }
    }
}
