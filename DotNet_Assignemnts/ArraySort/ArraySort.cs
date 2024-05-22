namespace DotNet_Assignemnts.ArraySort;

public  class ArraySort
{
    public int[] numberArray; 
    public ArraySort(int[] array)
    {
        numberArray = array;
    }

    //Method That Sorts an integer Array 
    public void SortMethod(int[] numbers)
    {
        Console.WriteLine("Before Sorting");
        DisplayArray(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 1; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j - 1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j - 1];
                    numbers[j - 1] = temp;
                }
            }

        }
        Console.WriteLine();
        Console.WriteLine("After Sorting");
        DisplayArray(numbers);
    }

    //Method that Displays Array Elements
    static void DisplayArray(int[] intArray)
    {
        foreach (int number in intArray)
        {
            Console.Write(number + " ");

        }
        Console.WriteLine();
    }
}
