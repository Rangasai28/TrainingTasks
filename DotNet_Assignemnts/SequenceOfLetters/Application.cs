namespace DotNet_Assignemnts.SequenceOfLetters;

public class Application
{
    public static void Start(string[] args)
    {
        Console.WriteLine("Enter String of two Letters:");
        string lettersString = Console.ReadLine();

        if ((int)lettersString[0] < (int)lettersString[1])
        {
            Console.WriteLine(SequenceOfLetters.SequenceBetweenLetters(lettersString));
        }
        else
        {
            Console.WriteLine("fisrt letter should be before second letter ");
        }
    }
    
}
