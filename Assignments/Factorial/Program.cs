namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number to calculate the Factorial:");
            int number = Convert.ToInt32(Console.ReadLine());
            Program obj = new Program();
            int factorialValue = obj.Factorial(number);
            Console.WriteLine("Factorial Of {0} is {1}",number,factorialValue);
        }


        public int Factorial(int number)
        {
            if(number == 0 || number == 1)
            {
                return 1;
            }
            else if(number == 2)
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
}
