namespace DotNet_Assignemnts.SortingTechniques;

public  class Application
{
    public static void Start(string[] args)
    {
        int[] arr = new int[] { 44, 2, 55, 1, 5, 100, 23, 43, 12, 54 };
        SortingTechniques.BubbleSort(arr);
        SortingTechniques.PrintArray(arr);
        SortingTechniques.SelectionSort(arr);
        SortingTechniques.PrintArray(arr);
    }
    
}
