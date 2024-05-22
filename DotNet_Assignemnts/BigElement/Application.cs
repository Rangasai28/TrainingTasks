namespace DotNet_Assignemnts.BigElement;

public class Application
{
    public static void Start(string[] args)
    {
        int[] numberArray = { 100, 2, 45, 22, 43, 51, 85, 3, 56 };
        int[] numberArray2 = { 33, 2, 5, 1, 8, 45, 34, 83 };

        BigElement bigElement = new BigElement();

        int[] sortedArray = bigElement.SortMethod(numberArray);
        Console.WriteLine("Largest Element is : {0}", sortedArray[sortedArray.Length - 1]);

        int[] sortedArray2 = bigElement.SortMethod(numberArray2);
        Console.WriteLine("Largest Element is : {0}", sortedArray2[sortedArray2.Length - 1]);
    }
    
}
