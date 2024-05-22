namespace DotNet_Assignemnts.PowerOfNumber;

public  class Application
{
    public static void Start(string[] args)
    {
        int baseNumber, exponent;

        Console.WriteLine("Enter Base Vale:");
        baseNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Exponent Value:");
        exponent = Convert.ToInt32(Console.ReadLine());

        int result = PowerOfNumber.PowerOfNum(baseNumber, exponent);
        Console.WriteLine($" {baseNumber} to the Powerof {exponent} is {result}");
    }
}
