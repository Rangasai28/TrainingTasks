namespace DotNet_Assignemnts.ReverseANumber;

public  class Application
{
    public static void Start(string[] args)
    {
        ReverseANumber reverseANumber = new ReverseANumber();
        Console.Write("Enter The Number To Reverse:");
        reverseANumber.ReversedNumber(Convert.ToInt32(Console.ReadLine()));
    }
}
