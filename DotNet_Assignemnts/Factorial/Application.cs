namespace DotNet_Assignemnts.Factorial;

public  class Application
{
    public static void Start(string[] args)
    {
        Console.Write("Enter the number to calculate the Factorial:");
        int number = Convert.ToInt32(Console.ReadLine());
        Factorial factorial = new Factorial();
        int factorialValue = factorial.Fact(number);
        Console.WriteLine("Factorial Of {0} is {1}", number, factorialValue);
    }
   
}
