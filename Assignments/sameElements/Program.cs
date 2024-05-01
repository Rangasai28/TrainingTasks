/*
 * Program to DISPLAY	THE	COMMON ELEMENTS between two arrays.
 */
namespace sameElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
            int[] array2 = { 6, 12, 18, 24, 30, 36, 48, 54, 60 };
            int[] array3 = { 9, 18, 27, 36, 45, 54, 63, 72, 81, 90 };
            Console.WriteLine("Common Elements Are:");
            commonElements(array1, array3);

        }


        //Method That Return The Common Elements Between Two Arrays as List 
        static int[] commonElements(int[] array1, int[] array2)
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
}
