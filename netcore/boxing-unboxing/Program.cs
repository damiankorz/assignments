using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an empty List of type object
            List<object> objList = new List<object>();
            //add the following values to the list: 7, 28, -1, true, "chair"
            objList.Add(7);
            objList.Add(28);
            objList.Add(-1);
            objList.Add(true);
            objList.Add("chair");
            //loop through the list and print all values 
            foreach (var obj in objList){
                Console.WriteLine(obj);
            }
            //add all values that are int type together and output the sum
            int intSum = 0;
            //for each object in the list, check if the object is of type integer
            foreach (var obj in objList){
                if (obj is int){
                    //if object is of type integer, cast it and add to sum 
                    int castInt = (int)obj;
                    intSum += castInt;
                }
            }
            Console.WriteLine("Sum of Integers: {0}", intSum);
        }
    }
}
