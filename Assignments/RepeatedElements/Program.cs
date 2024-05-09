/*
 * Program to Print the elements with no of times it is repeated in the array and remove duplicate elements from an Array
 */

namespace RepeatedElements;

public static class Program
{
    //Main Method
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 1, 1, 2 };

        CountOfEachElement(array);
        Console.WriteLine();
        RemoveDuplicates(array);
    }

    //Method That Counts Occurences of Each Integer Element  in an Integer Array
    public static void CountOfEachElement(int[] array)
    {
        //Displays How Many Times Each Element is Present in The Array
        for (int i = 0; i < array.Length; i++)
        {
            int count = 1;

            if (array[i] != 0)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                        array[j] = 0;
                    }
                }
                Console.WriteLine($"Element {array[i]} : Count {count}");
            }
        }
    }

    //Method that Removes the Duplicate Elements in An Integer Array
    static void RemoveDuplicates(int[] array)
    {
        List<int> list = new List<int>();

        //Adding Elements into the List that are not repeated
        for (int i = 0; i < array.Length; i++)
        {
            if (!list.Contains(array[i]))
            {
                list.Add(array[i]);
            }
        }

        //Displaying the Array after removing the Duplicate Elements
        Console.WriteLine("Array after removing Duplicate Elements ");
        for (int i = 0; i < list.Count - 1; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
