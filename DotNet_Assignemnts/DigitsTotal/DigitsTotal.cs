namespace DotNet_Assignemnts.DigitsTotal;

public  class DigitsTotal
{
    public  void DescendingSort(int[] list)
    {
        //Sorting the list in Decending Order
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = 1; j < list.Length; j++)
            {
                if (list[i] > list[j - 1])
                {
                    int temp1 = list[i];
                    list[i] = list[j - 1];
                    list[j - 1] = temp1;
                }
            }

        }
    }
}
