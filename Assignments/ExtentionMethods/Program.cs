namespace ExtentionMethods
{
    public static  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ExtendingClass extentionClass = new ExtendingClass();
            Console.WriteLine(extentionClass.Mul(10, 20));
            Console.WriteLine(extentionClass.Div(20, 10));

            int i = 5;
            Console.WriteLine("The Factorial of 5 is :{0}", i.Factorial());

            string oldstring = "hEllo hOW ArE YOU";
            Console.WriteLine(oldstring.ToProperCase());

            Console.WriteLine("5 to the Power of 4 is : {0}", extentionClass.PowerOfNumber(5, 4));
        }
    }
}
