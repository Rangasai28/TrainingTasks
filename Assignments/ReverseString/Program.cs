/*
 * Program to Reverse a  string without using Inbuilt functions.
 */

namespace ReverseString;
internal static class Program
{
    static void Main(string[] args)
    {
        string inputString = "hello";
        Console.WriteLine("Original string: " + inputString);
        for (int i = inputString.Length - 1; i >= 0; i--)
        {
            Console.Write(inputString[i]);
        }
    }
}

