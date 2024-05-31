using System.Text;

namespace DotNet_Assignemnts.ExtentionMethods;

public static  class ExtentionClass
{
    //Extention Methods for the user defined type ExtendingClass
    public static int Mul(this ExtendingClass extentionClass, int a, int b)
    {

        return a * b;
    }

    public static int Div(this ExtendingClass ec, int a, int b)
    {
        return a / b;
    }
    public static int PowerOfNumber(this ExtendingClass ec, int baseValue, int exponentValue)
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
            return baseValue * ec.PowerOfNumber(baseValue, exponentValue - 1);
        }
    }

    //Extending a  Method  for a Pre-defined Structure
    public static int Factorial(this Int32 value)
    {
        if (value == 1 || value == 0)
        {
            return 1;
        }
        else if (value == 2)
        {
            return 2;
        }
        else
        {
            return value * Factorial(value - 1);
        }
    }

    //Extending  Method for In-Built class  
    public static string ToProperCase(this String OldString)
    {
        StringBuilder NewString = new StringBuilder();
        if (!String.IsNullOrEmpty(OldString))
        {
            OldString = OldString.ToLower();
            string[] Words = OldString.Split(' ');

            foreach (string W in Words)
            {
                char[] chars = W.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                NewString.Append(chars);
                NewString.Append(" ");
            }
            return NewString.ToString();
        }
        return OldString;
    }
}
