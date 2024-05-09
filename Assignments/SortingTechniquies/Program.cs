namespace SortingTechniquies;

internal class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        int[] array = new int[] { 44, 2, 55, 1, 5, 100, 23, 43, 12, 54 };
        Console.WriteLine("Using BubbleSort");
        program.BubbleSort(array);
        program.PrintArray(array);
        Console.WriteLine();
        Console.WriteLine("Using SelectionSort");
        program.SelectionSort(array);
        program.PrintArray(array);
    }
    public void BubbleSort(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length-1; i++)
        {
            for (int j = 0; j < length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    public void SelectionSort(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }
    public void PrintArray(int[] array)
    {
        for(int i = 0;i < array.Length;i++)
        {
            Console.Write(array[i]+" ");
        }
        Console.WriteLine();
    }
}
