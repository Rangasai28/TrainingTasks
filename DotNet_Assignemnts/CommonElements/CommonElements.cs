namespace DotNet_Assignemnts.CommonElements;

public class CommonElements
{
    //Method That Return The Common Elements Between Two Arrays as List 
    public static int[] CommonItems(int[] array1, int[] array2)
    {
        int count = 0;

        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                if (array1[i] == array2[j])
                {
                    count++;
                }
            }
        }


        int[] list = new int[count];

        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {

                if (array1[i] == array2[j])
                {
                    Console.Write(array1[i] + " ");
                }


            }
        }
        return list;

    }
}
