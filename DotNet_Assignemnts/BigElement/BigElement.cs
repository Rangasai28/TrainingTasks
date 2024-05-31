namespace DotNet_Assignemnts.BigElement;

public  class BigElement
{
    public int[] SortMethod(int[] numbers)
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
