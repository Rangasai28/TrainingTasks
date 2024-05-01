/*
 * Program to display OCCURENCES of  each character in a STRING
 */

namespace CharOccurence
{
    internal class Program
    {
        //Method That Counts Occurences of Each Char in a string
        static void countOfEachChar(string str)
        {
            char[] ch = new char[str.Length];

            //Converting String To Char Array
            for (int i = 0; i < str.Length; i++)
            {
                ch[i] = str[i];
            }

            //Counts The Occurence Of each Char using For Loop
            for (int i = 0; i < ch.Length; i++)
            {
                int count = 1;

                if (!ch[i].Equals('0'))
                {
                    for (int j = i + 1; j < ch.Length; j++)
                    {
                        if (ch[i] == ch[j])
                        {
                            count++;

                            ch[j] = '0';
                        }
                    }
                    Console.WriteLine($"Element {ch[i]} : Count {count}");
                }
            }
        }

        //Main Method
        static void Main(string[] args)
        {

            string str = "bala ranga sai";
            countOfEachChar(str);
        }
    }
}