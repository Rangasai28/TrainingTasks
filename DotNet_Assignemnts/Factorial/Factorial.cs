namespace DotNet_Assignemnts.Factorial;

public  class Factorial
{
    public int Fact(int number)
    {
        if (number == 0 || number == 1)
        {
            return 1;
        }
        else if (number == 2)
        {
            return 2;
        }
        else
        {
            int value = number;
            for (int i = 1; i < number; i++)
            {
                value *= i;
            }
            return value;
        }



    }
}
