namespace DotNet_Assignemnts.DigitsTotal;
public class Application
{
    public static void Start(string[] args)
    {
        DigitsTotal digitsTotal = new DigitsTotal();
        Console.WriteLine("Enter The Number:");
        int number = Convert.ToInt32(Console.ReadLine());
        int temp = number;
        int count = 0;
        int r;
 
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

        digitsTotal.DescendingSort(list);

        //Displaying the biggest integer that can be formed using the given integer
        Console.WriteLine($"The Biggest number we can form using {number} is :");
        foreach (int i in list)
        {
            Console.Write(i);
        }
    }

}
