namespace DotNet_Assignemnts.PatternPrinting;

internal class Application
{
    public static void Start(string[] args)
    {
        PatternPrinting.PattrenPrinting();
        Console.WriteLine();
        PatternPrinting.OneToHundred();
        Console.WriteLine();
        PatternPrinting.EvenNumber(100);
        Console.WriteLine();
        PatternPrinting.MultiplicationTable(5, 10);
        Console.WriteLine();
        PatternPrinting.SumOfDigits(654321);
        Console.WriteLine();
        PatternPrinting.PrimeNumbers(100);
        Console.WriteLine();
        PatternPrinting.SumOfSeries(5);
    }
   
}
