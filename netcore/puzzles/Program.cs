using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(5);
            Names();
        }
        /*Create a function called RandomArray that returns an integer array 
        Place 10 random integer values between 5-25 into the array
        Print the min and max values of the array 
        Print the sum of all the values  */
        public static int[] RandomArray(){
            int[] arr = new int[10];
            Random rand = new Random();
            for (int idx = 0; idx < arr.Length; idx++){
                arr[idx] = rand.Next(5,26);
            }
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            foreach (int num in arr){
                sum += num;
                if (num > max){
                    max = num;
                }
                else if (num < min){
                    min = num;
                }
            }
            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
            return arr;
        }
        /*Create a function called TossCoin() that returns a string
        Have the function print "Tossing a Coin!"
        Randomize a coin toss with a result signaling either side of the coin
        Have the function print either "Heads" or "Tails"
        Return the result */
        public static string TossCoin(){
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int chance = rand.Next(0,2);
            string result;
            if (chance == 0){
                result = "Tails";
            }
            else {
                result = "Heads";
            }
            Console.WriteLine(result);
            return result;
        }
        /*Create a function called TossMultipleCoins(int num) that returns a Double
        Have the function call the tossCoin function multiple times based on num value
        Have the function return a Double that reflects the ratio of head toss to total toss */
        public static double TossMultipleCoins(int num = 1){
            if (num < 1){
                throw new ArgumentOutOfRangeException("num", "entered argument 'num' must be greater than or equal to 1");
            }
            int countHeads = 0;
            int countTotal = 0;
            for (int i = 1; i <= num; i++){
                countTotal += 1;
                string result = TossCoin();
                if (result == "Heads"){
                    countHeads += 1;
                }
            }
            double ratio = (double)countHeads / (double)countTotal;
            Console.WriteLine($"The ratio of heads to total tosses is: {ratio}");
            return ratio;
        }
        /*Build a function Names that return an array of strings
        Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        Shuffle the array and print the values in the new order 
        Return an array that only includes names longer than 5 characters */
        public static string[] Names(){
            string[] nameArr = new string[5] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            for (int idx = 0; idx < nameArr.Length-1; idx++){
                int randIdx = rand.Next(idx+1, nameArr.Length - 1);
                string temp = nameArr[idx];
                nameArr[idx] = nameArr[randIdx];
                nameArr[randIdx] = temp;
                Console.WriteLine(nameArr[idx]);
            }
            Console.WriteLine(nameArr[nameArr.Length-1]);
            List<string> nameList = new List<string>();
                foreach (string name in nameArr){
                    nameList.Add(name);
                }
            return nameList.ToArray();
        }
    }
}
