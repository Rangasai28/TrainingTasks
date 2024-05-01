/*
 * Program To Print the number of digits in a given integer and  the biggest number that can form with these digits
 */

namespace DigitsTotal
{
    internal class Program
    {
        public static void descendingSort(int[] list)
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

        //Main Method
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Number:");
            int number = Convert.ToInt32(Console.ReadLine());
            int temp = number;
            int count = 0;
            int r;
            //List<int> list = new List<int>();


            //Adding each digit into list and increasing the count
            while (number != 0)
            {

                //r = number % 10;
                number = number / 10;
                count++;
            }
            number = temp;

            //Displaying total number of digits in the given integer
            Console.WriteLine($"The Total Number of Digits in the Number {number} is :{count}");

            //Creating List Array
            int[] list = new int[count];

            //Adding Each Digit Into The List Array Using Loop
            while (number != 0)
            {

                for (int i = 0; i < count; i++)
                {
                    r = number % 10;
                    list[i] = r;
                    number = number / 10;
                }


            }
            number = temp;

            descendingSort(list);

            //Displaying the biggest integer that can be formed using the given integer
            Console.WriteLine($"The Biggest number we can form using {number} is :");
            foreach (int i in list)
            {
                Console.Write(i);
            }
        }
    }
}

