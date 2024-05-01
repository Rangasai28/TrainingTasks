/*
 * Program to Print the elements with no of times it is repeated in the array and remove duplicate elements from an Array
 */

namespace RepeatedElements
{
    class Program
    {
        //Method That Counts Occurences of Each Integer Element  in an Integer Array
        public static void countOfEachElement(int[] ar)
        {
            //Displays How Many Times Each Element is Present in The Array
            for (int i = 0; i < ar.Length; i++)
            {
                int count = 1;

                if (ar[i] != 0)
                {
                    for (int j = i + 1; j < ar.Length; j++)
                    {
                        if (ar[i] == ar[j])
                        {
                            count++;
                            ar[j] = 0;
                        }
                    }
                    Console.WriteLine($"Element {ar[i]} : Count {count}");
                }
            }
        }

        //Method that Removes the Duplicate Elements in An Integer Array
        static void removeDuplicates(int[] ar)
        {
            List<int> list = new List<int>();

            //Adding Elements into the List that are not repeated
            for (int i = 0; i < ar.Length; i++)
            {
                if (!list.Contains(ar[i]))
                {
                    list.Add(ar[i]);
                }
            }

            //Displaying the Array after removing the Duplicate Elements
            Console.WriteLine("Array after removing Duplicate Elements ");
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write(ar[i] + " ");
            }
            Console.WriteLine();
        }

        //Main Method
        static void Main()
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 1, 1, 2 };

            countOfEachElement(ar);
            removeDuplicates(ar);
        }
    }

}
