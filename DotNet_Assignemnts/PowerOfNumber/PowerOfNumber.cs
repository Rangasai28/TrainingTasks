namespace DotNet_Assignemnts.PowerOfNumber;

public  class PowerOfNumber
{
    public static int PowerOfNum(int baseValue, int exponentValue)
    {
        if (exponentValue == 0)
        {
            return 1;
        }
        else if (exponentValue == 1)
        {
            return baseValue;
        }
        else
        {
            return baseValue * PowerOfNum(baseValue, exponentValue - 1);
        }
    }
}
