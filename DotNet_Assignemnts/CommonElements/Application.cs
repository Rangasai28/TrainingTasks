namespace DotNet_Assignemnts.CommonElements;

public class Application
{
    public static void Start(string[] args)
    {
        int[] array1 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
        int[] array2 = { 6, 12, 18, 24, 30, 36, 48, 54, 60 };
        int[] array3 = { 9, 18, 27, 36, 45, 54, 63, 72, 81, 90 };
        Console.WriteLine("Common Elements Are:");
        CommonElements.CommonItems(array1, array3);
        CommonElements.CommonItems(array2, array3);
    }
   
}
