/*
 * Program to REVERSE the number
 */

namespace NumberReverse;

internal static  class Program
{
    //Main Method
    static void Main(string[] args)
    {
        Console.Write("Enter The Number To Reverse:");
        ReverseNumber(Convert.ToInt32(Console.ReadLine()));
    }

    //Method That Reverses The Given Number
    static void ReverseNumber(int number)
    {
        int reminder, sum = 0;
        while (number != 0)
        {
            reminder = number % 10;
            sum = reminder + (sum * 10);
            number = number / 10;
        }
        Console.WriteLine(sum);
    }
}
