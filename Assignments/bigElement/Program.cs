namespace BigElement;

internal class Program
{
    //Main Method
    static void Main(string[] args)
    {
        int[] integerArray1 = { 100, 2, 45, 22, 43, 51, 85, 3, 56 };
        int[] integerArray2 = { 33, 2, 5, 1, 8, 45, 34, 83 };

        int[] sortedArray = SortMethod(integerArray1);
        Console.WriteLine("Largest Element is : {0}", sortedArray[sortedArray.Length - 1]);

        int[] sortedArray2 = SortMethod(integerArray2);
        Console.WriteLine("Largest Element is : {0}", sortedArray2[sortedArray2.Length - 1]);
    }


    //Method That Sort the Integer Array In Ascending Order
    static int[] SortMethod(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 1; j < numbers.Length; j++)
            {
                if (numbers[i] < numbers[j - 1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j - 1];
                    numbers[j - 1] = temp;
                }
            }

        }
        return numbers;
    }
}

