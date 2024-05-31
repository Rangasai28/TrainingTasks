namespace DotNet_Assignemnts.ArraySort;

public static  class Application
{
    public static void Start(string[] args)
    {
        ArraySort arraySort1 = new ArraySort(new int[] { 100, 2, 45, 22, 43, 51, 85, 3, 56 });
        arraySort1.SortMethod(arraySort1.numberArray);
        Console.WriteLine();
        Console.WriteLine();
        ArraySort arraySort2 = new ArraySort(new int[] { 33, 2, 5, 1, 8, 45, 34, 83 });
        arraySort2.SortMethod(arraySort2.numberArray);
    }
}
