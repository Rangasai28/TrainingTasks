namespace DotNet_Assignemnts.Binary_IntegerConversion;

public class Binary_IntegerConversion
{
    //Method that converts binary value to integer
    public  int BinaryToInteger(string bits)
    {
        int result = 0;
        for (int i = bits.Length - 1, j = 0; i >= 0; i--, j++)
        {
            if (bits[i] == '1')
            {
                result += PowerOfNumber(2, j);
            }
        }
        return result;

    }

    //Method That Convert Integer value into Binary
    public  string IntegerToBinary(int number)
    {
        string binary = "";
        int remainder;
        while (number != 0)
        {
            remainder = number % 2;
            binary = remainder + binary;
            number = number / 2;
        }
        return binary;

    }

    public  int PowerOfNumber(int baseValue, int exponentValue)
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
            return baseValue * PowerOfNumber(baseValue, exponentValue - 1);
        }
    }

}