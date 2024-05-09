//Program That Calculates the Power of a Number USing Recursion

namespace PowerOfNumber;

internal static class Program
{
    //Main Method
    static void Main(string[] args)
    {
        int baseNumber,exponent;

        Console.WriteLine("Enter Base Vale:");
        baseNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Exponent Value:");
        exponent = Convert.ToInt32(Console.ReadLine());

        int result = PowerOfNumber(baseNumber, exponent);
        Console.WriteLine($"{baseNumber} to the Powerof {exponent} is {result}");
    }

    //Method that Returns the Power 
    public static int PowerOfNumber(int baseValue,int exponentValue)
    {
        if(exponentValue == 0)
        {
            return 1;
        }
        else if(exponentValue == 1)
        {
            return baseValue;
        }
        else
        {
            return baseValue * PowerOfNumber(baseValue, exponentValue - 1); 
        }
    }
}
