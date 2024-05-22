namespace DotNet_Assignemnts.ReverseANumber;

public  class ReverseANumber
{
    //Method That Reverses The Given Number
    public  void ReversedNumber(int n)
    {
        int reminder, s = 0;
        while (n != 0)
        {
            reminder = n % 10;
            s = reminder + (s * 10);
            n = n / 10;
        }
        Console.WriteLine(s);
    }
}
