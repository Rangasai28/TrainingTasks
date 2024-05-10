using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal static class Utility
    {
        public static  int ReadInteger()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 0 )
            {
                Console.WriteLine("Invalid input");
                Console.Write("Please enter an Non-Negative integer:");
            }
            return result;
        }
    }
}
