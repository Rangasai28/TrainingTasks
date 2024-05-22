namespace DotNet_Assignemnts.ReverseAString;

public  class Application
{
    public static void Start(string[] args)
    {
        //string str = "hello";
        Console.WriteLine("Enter String Value:");
       string  str = Console.ReadLine();
        Console.WriteLine("Original string: " + str);

        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }
}
