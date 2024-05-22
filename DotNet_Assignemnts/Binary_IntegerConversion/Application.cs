namespace DotNet_Assignemnts.Binary_IntegerConversion;

public class Application
{
    public static void Start(string[] args)
    {
        Binary_IntegerConversion binary_IntegerConversion = new Binary_IntegerConversion();
        Console.WriteLine("Enter Binary Value");
        string bits = Console.ReadLine();
        Console.WriteLine(binary_IntegerConversion.BinaryToInteger(bits));

        Console.WriteLine("Enter Integer Value:");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(binary_IntegerConversion.IntegerToBinary(number));
        Console.WriteLine();
    }
}
