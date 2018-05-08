using System;
using System.Collections.Generic;

namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an array to hold integer values 0 through 9 
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            //create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            //create an array of length 10 that alternates between true and false values, starting with true
            bool[] boolArray = new bool[10];
            for (int idx = 0; idx < 10; idx +=2){
                boolArray[idx] = true;
            }
            Console.WriteLine(boolArray[1]);
            //with the values 1-10, use code to generate a multiplication table
            int[,] multiplicationArray = new int[10,10];
            for (int x = 0; x < 10; x++){
                for (int y = 0; y < 10; y++){
                    multiplicationArray[x,y] = (x+1) * (y+1);
                }
            }
            for (int x = 0; x < 10; x++){
                string output = "[";
                for (int y = 0; y < 10; y++){
                    output += multiplicationArray[x,y] + " ";
                    if (multiplicationArray[x,y] < 10){
                        output += " ";
                    }
                }
                output += "]";
                Console.WriteLine(output);
            }
            //create a list of ice cream flavors that that holds a least 5 different flavors
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Strawberry");
            flavors.Add("Rocky Road");
            flavors.Add("Orange Sherbert");
            //output the length of the list after building it
            Console.WriteLine(flavors.Count);
            //output the third flavor in the list, then remove this value 
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            //output the new length of the list 
            Console.WriteLine(flavors.Count);
            //create a dictionary that will store both string keys as well as string values
            //for each name in the array of names, add it as a new key in this dictionary 
            //for each name key, select a random flavor from the flavor list above and store it as the value
            //loop through the Dictionary and print out each user's name and their associated ice cream flavor
            Dictionary<string,string> favFlavors = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (string name in nameArray){
                favFlavors[name] = flavors[rand.Next(flavors.Count)];
            }
            foreach (var entry in favFlavors){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
