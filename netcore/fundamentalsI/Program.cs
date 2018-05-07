using System;

namespace fundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            //prints values 1-255
            for (int i = 1; i < 256; i++){
                Console.WriteLine(i);
            }
            // prints values 1-100 that are divisible by 3 or 5 but not both
            for (int i = 1; i < 101; i++){
                if (i % 3 == 0 || i % 5 == 0){
                    if (i % 3 == 0 && i % 5 == 0){
                    }
                    else {
                        Console.WriteLine(i);
                    }
                }
            }
            // prints values 1-100. If number divisible by 3 print "Fizz", by 5 print "Buzz", by both print "FizzBuzz"
            for (int i = 1; i < 101; i++){
                if (i % 3 == 0 && i % 5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0 && i % 5 != 0){
                    Console.WriteLine("Fizz");
                }
                else if (i % 3 != 0 && i % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                else {
                    Console.WriteLine(i);
                }
            }
            // fizzbuzz as above without the use of modulo
            for (int i = 1; i < 101; i++){
                if (i / 3 == i / 3.0 && i / 5 == i / 5.0){
                    Console.WriteLine("FizzBuzz");
                }
                else if (i / 3 == i / 3.0 && i / 5 != i / 5.0){
                    Console.WriteLine("Fizz");
                }
                else if (i / 3 != i / 3.0 && i /5 == i / 5.0){
                    Console.WriteLine("Buzz");
                }
                else {
                    Console.WriteLine(i);
                }
            }
            // Generate 10 random values. If rand num divisible by 3 print "Fizz", by 5 print "Buzz", by both print "FizzBuzz"
            Random rand = new Random();
            for (int i = 1; i < 11; i++){
                int randInt = rand.Next(1,100);
                if (randInt % 3 == 0 && randInt % 5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if (randInt % 3 == 0 && randInt % 5 != 0){
                    Console.WriteLine("Fizz");
                }
                else if (randInt % 3 != 0 && randInt % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                else {
                    Console.WriteLine(randInt);
                }
            }
        }
    }
}
