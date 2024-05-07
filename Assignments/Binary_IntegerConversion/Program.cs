namespace Binary_IntegerConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Binary Value");
            string bits = Console.ReadLine();
            Console.WriteLine(binaryToInteger(bits));

            Console.WriteLine("Enter Integer Value:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(IntegerToBinary(number));
            Console.WriteLine();
        }


        //Method that converts binary value to integer
        public static int binaryToInteger(string bits)
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
        public static string IntegerToBinary(int number)
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

        public static int PowerOfNumber(int baseValue, int exponentValue)
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
}
