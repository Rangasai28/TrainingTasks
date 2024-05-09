/*
 * Program To Print the number of digits in a given integer and  the biggest number that can form with these digits
 */

namespace DigitsTotal;

internal static class Program
{
    //Main Method
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter The Number:");
        int number = Convert.ToInt32(Console.ReadLine());
        int temp = number;
        int count = 0;
        int remainder;

        //Adding each digit into list and increasing the count
        while (number != 0)
        {
            number = number / 10;
            count++;
        }
        number = temp;

        //Displaying total number of digits in the given integer
        Console.WriteLine($"The Total Number of Digits in the Number {number} is :{count}");

        //Creating List Array
        int[] array = new int[count];

        //Adding Each Digit Into The List Array Using Loop
        while (number != 0)
        {
            for (int i = 0; i < count; i++)
            {
                remainder = number % 10;
                array[i] = remainder;
                number = number / 10;
            }
        }
        number = temp;
        DescendingSort(array);

        //Displaying the biggest integer that can be formed using the given integer
        Console.WriteLine($"The Biggest number we can form using {number} is : ");
        foreach (int i in array)
        {
            Console.Write(i);
        }
    }

    public static void DescendingSort(int[] array)
    {
        //Sorting the list in Decending Order
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 1; j < array.Length; j++)
            {
                if (array[i] > array[j - 1])
                {
                    int temp1 = array[i];
                    array[i] = array[j - 1];
                    array[j - 1] = temp1;
                }
            }

        }
    }
}

