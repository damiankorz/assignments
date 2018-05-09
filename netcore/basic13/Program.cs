using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintRange();
            PrintOdds();
            PrintSum();
            int[] numArr = new int[6] {1,3,5,7,9,13};
            IterArray(numArr);
            FindMax(numArr);
            PrintAvg(numArr);
            OddArray();
            GreaterThanY(numArr, 3);
            SquaredArr(numArr);
            int[] negArr = new int[4] {-1, 5, 10, -2};
            ElimNegative(negArr);
            MaxMinAvg(numArr);
            ShiftArray(numArr);
            object[] boxedArr = new object[3] {-1, -3, -2};
            NumToString(boxedArr);
        }
        public static void PrintRange(){
            for (int i = 1; i < 256; i++){
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds(){
            for (int i = 1; i < 256; i++){
                if (i % 2 != 0){
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum(){
            int intSum = 0;
            for (int i = 0; i < 256; i++){
                intSum += i;
                Console.WriteLine("New Number: {0}, Sum: {1}", i, intSum);
            }
        }
        public static void IterArray(int[] arr){
            foreach (int num in arr){
                Console.WriteLine(num);
            }
        }
        public static void FindMax(int[] arr){
            int maxNum = arr[0];
            foreach (int num in arr){
                if (num > maxNum){
                    maxNum = num;
                }
            }
            Console.WriteLine("The max number in the array is {0}", maxNum);
        }
        public static void PrintAvg(int[] arr){
            int sum = 0;
            foreach (int num in arr){
                sum += num;
            }
            double castSum = (double)sum;
            double avg = (castSum / arr.Length);
            Console.WriteLine("The average of the array is {0}", avg);
        }
        public static void OddArray(){
            List<int> odds = new List<int>();
            for (int i = 1; i < 256; i++){
                if (i % 2 != 0){
                    odds.Add(i);
                }
            }
            int[] oddsArr = odds.ToArray();
            string output = "[";
            foreach (int num in oddsArr){
                output += num + ",";
            }
            output += "]";
            Console.WriteLine(output);
        }
        public static void GreaterThanY(int[] arr, int y){
            int count = 0;
            foreach (int num in arr){
                if (num > y){
                    count += 1;
                }
            }
            Console.WriteLine("Numbers greater than y: {0}", count);
        }
        public static void SquaredArr(int[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                arr[idx] *= arr[idx];
            }
            string output = "[";
            foreach (int num in arr){
                output += num + ",";
            }
            output += "]";
            Console.WriteLine(output);
        }
        public static void ElimNegative(int[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if (arr[idx] < 0){
                    arr[idx] = 0;
                }
            }
            string output = "[";
            foreach (int num in arr){
                output += num + ",";
            }
            output += "]";
            Console.WriteLine(output);
        }
        public static void MaxMinAvg(int[] arr){
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
            double castSum = (double)sum;
            double avg = (castSum / arr.Length);
            Console.WriteLine($"Max: {max}, Min: {min}, Avg: {avg}");
        }
        public static void ShiftArray(int[] arr){
            for (int idx = 0; idx < arr.Length-1; idx++){
                arr[idx] = arr[idx + 1];
            }
            arr[arr.Length-1] = 0;
            string output = "[";
            foreach (int num in arr){
                output += num + ",";
            }
            output += "]";
            Console.WriteLine(output);
        }
        public static object[] NumToString(object[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if ((int)arr[idx] < 0){
                    arr[idx] = "Dojo";
                }
            }
            return arr;
        }
    }
}
