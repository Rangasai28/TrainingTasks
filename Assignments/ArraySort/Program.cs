/*
 * Program to Sort an ineteger array without using Inbuilt functions.
 */

namespace ArraySort
{
    internal class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            int[] numberList = { 100, 2, 45, 22, 43, 51, 85, 3, 56 };
            int[] numberList2 = { 33, 2, 5, 1, 8, 45, 34, 83 };
            int[] n = { 5, 8, 2, 3 };
            sortMethod(numberList);
            sortMethod(numberList2);
            sortMethod(n);
        }

        //Method That Sorts an integer Array 
        static void sortMethod(int[] numbers)
        {
            Console.WriteLine("Before Sorting");
            DisplayArray(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j - 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j - 1];
                        numbers[j - 1] = temp;
                    }
                }

            }
            Console.WriteLine("After Sorting");
            DisplayArray(numbers);
        }

        //Method that Displays Array Elements
        static void DisplayArray(int[] intArray)
        {
            foreach (int number in intArray)
            {
                Console.Write(number + " ");

            }
            Console.WriteLine();
        }
    }
}
