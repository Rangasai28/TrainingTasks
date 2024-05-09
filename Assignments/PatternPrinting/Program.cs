namespace PatternPrinting;

internal static class Program
{
    static void Main(string[] args)
    {
        PattrenPrinting();
        Console.WriteLine();
        OneToHundred();
        Console.WriteLine();
        EvenNumber(100);
        Console.WriteLine();
        MultiplicationTable(5, 10);
        Console.WriteLine();
        SumOfDigits(654321);
        Console.WriteLine();
        PrimeNumbers(100);
        Console.WriteLine();
        SumOfSeries(5);
    }

    /*
     * Method to Print The Following Pattern
     *  *
     *  **
     *  ***
     *  ****
     *  ***** 
     */
    public static void PattrenPrinting()
    {
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    //Method To Print Numbers From 1 To 100
    public static void OneToHundred()
    {
        for(int i = 1; i <= 100; i++)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
    }

    //Program to print only even numbers from 1 to 100.
    public static void EvenNumber(int n)
    {
        for (int i = 1; i <= 100; i++)
        {
            if(i%2 == 0)
            {
                Console.Write($"{i} ");
            }
            
        }
        Console.WriteLine();
    }

    //program that prints the multiplication table of a given number
    public static void MultiplicationTable(int n,int limit)
    {
        for(int i = 1; i <= limit; i++)
        {
            Console.WriteLine($"{n} * {i} = {n*i}");
        }
        Console.WriteLine();
    }

    //Method to Print Sum of Digits in the Given Number
    public static void SumOfDigits(int number)
    {
        int remainder, temp = number, sum = 0;
        while (number != 0)
        {
            remainder = number % 10;
            sum +=  remainder;
            number /= 10;
        }

        Console.WriteLine("The Sum of the Digits of {0} is {1}",temp,sum);

    }

    //Program To Check if a number is Prime Or Not
    public static bool IsPrime(int number)
    {
        int count =0;
        for(int i = 1; i <= number; i++)
        {
           if(number%i == 0)
           {
                count++;
           }
        }
        if(count == 2)
        {
            return true;
        }
        return false;
    }

    //Method that Prints Prime Numbers Between the Given Limit
    public static void PrimeNumbers(int limit)
    {
        for(int i = 2;i <= limit; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i+" ");
            }
        }
    }

    //Method That Calculate the Sum of the Series 1 + 1/2 + 1/3 + ... + 1/n.

    public static void SumOfSeries(int nthvalue)
    {
        float sum =1f;
        for(int i = 2;i <= nthvalue; i++)
        {
            sum += 1f/i;
        }
        Console.WriteLine("Sum of the Series is :{0} ",sum);
    }
}
