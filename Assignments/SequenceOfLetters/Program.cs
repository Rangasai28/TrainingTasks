/*
 * Program That Prints Sequence of letters between string of two Letters 
 * 
 */
using System.Text;

namespace SequenceOfLetters
{
    internal class Program
    {
        //Method That retuen the string of letters that are between the Two letters
        public static string SequenceBetweenLetters(string str)
        {
            StringBuilder sb = new StringBuilder(); 
           
                for (int i = (int)str[0]; i <= (int)str[1]; i++)
                {
                    sb.Append((char)i + " ");
                }
                return sb.ToString();
           
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String of two Letters:");
            string lettersString = Console.ReadLine();
           
            if((int)lettersString[0] < (int)lettersString[1])
            {
                Console.WriteLine(SequenceBetweenLetters(lettersString));
            }
            else
            {
                Console.WriteLine("fisrt letter should be before second letter ");
            }


        }
    }
}
