using System.Text;

namespace DotNet_Assignemnts.SequenceOfLetters;

public  class SequenceOfLetters
{
    public static string SequenceBetweenLetters(string str)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = (int)str[0]; i <= (int)str[1]; i++)
        {
            sb.Append((char)i + " ");
        }
        return sb.ToString();
    }
}
