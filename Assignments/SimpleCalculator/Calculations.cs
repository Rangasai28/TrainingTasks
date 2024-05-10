using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator;

internal class Calculations
{
    public void Addition()
    {
        Console.Write("Enter First Number:");
        int numberOne = Utility.ReadInteger();
        Console.Write("Enter Second Number:");
        int numberTwo = Utility.ReadInteger();
        Console.WriteLine($"The Addition Of {numberOne} and {numberTwo} is {numberOne + numberTwo}");
        Console.WriteLine();
    }

    public void  Subtraction()
    {
        Console.Write("Enter First Number:");
        int numberOne = Utility.ReadInteger();
        Console.Write("Enter Second Number:");
        int numberTwo = Utility.ReadInteger();
        while (numberTwo > numberOne)
        {
            Console.WriteLine("The Second Number Must be Smaller Than First Number");
            Console.Write("Re-Enter Number Two:");
            numberTwo = Utility.ReadInteger();
        }
        Console.WriteLine($"The Subtraction Of {numberOne} and {numberTwo} is {numberOne - numberTwo}");
        Console.WriteLine();
    }

    public void Multiplication()
    {
        Console.Write("Enter First Number:");
        int numberOne = Utility.ReadInteger();
        Console.Write("Enter Second Number:");
        int numberTwo = Utility.ReadInteger();
        long result;
        result = numberOne * numberTwo;
        Console.WriteLine($"The Multipication of {numberOne} and {numberTwo} is : {result}");
    }
    public void Division()
    {
        Console.Write("Enter First Number:");
        int numberOne = Utility.ReadInteger();
        Console.Write("Enter Second Number:");
        int numberTwo = Utility.ReadInteger();
        float result;
        while (numberTwo == 0)
        {
            Console.WriteLine("The Second Number Cannot be Zero");
            Console.Write("Re-Enter Number Two:");
            numberTwo = Utility.ReadInteger();
        }
        result = (float)numberOne / numberTwo;
        Console.WriteLine($"The Division of {numberOne} and {numberTwo} is : {result}");
    }
}
