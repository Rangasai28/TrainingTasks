/*
 * Program to Reverse a  string without using Inbuilt functions.
 */

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "hello";
            Console.WriteLine("Original string: " + str);

            for (int i = str.Length - 1; i > 0; i--)
            {
                Console.Write(str[i]);
            }

        }
    }
}

