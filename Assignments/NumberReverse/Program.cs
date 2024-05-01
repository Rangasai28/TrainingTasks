/*
 * Program to REVERSE the number
 */

namespace NumberReverse
{
    internal class Program
    {

        //Main Method
        static void Main(string[] args)
        {
            Console.Write("Enter The Number To Reverse:");
            reversedNumber(Convert.ToInt32(Console.ReadLine()));
        }


        //Method That Reverses The Given Number
        static void reversedNumber(int n)
        {
            int reminder, s = 0;
            while (n != 0)
            {
                reminder = n % 10;
                s = reminder + (s * 10);
                n = n / 10;
            }
            Console.WriteLine(s);
        }
    }
}
