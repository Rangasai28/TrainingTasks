namespace DictionaryPractice;
internal class Program
{
    public enum menuOptions
    {
        AddStudent = 1,
        DeleteStudent,
        UpdateStudent,
        DisplayStudent,
        ListofStudents,
        Exit
    }
    static void Main(string[] args)
    {
        menuOptions uoption = Program.ReadUserOption();

        do
        {

            switch (uoption)
            {
                case menuOptions.AddStudent:
                    DoOperations.AddProduct();
                    break;
                case menuOptions.DeleteStudent:
                    DoOperations.DeleteProduct();
                    break;
                case menuOptions.UpdateStudent:
                    DoOperations.UpdateProduct();
                    break;
                case menuOptions.DisplayStudent:
                    DoOperations.DisplayProduct();
                    break;
                case menuOptions.ListofStudents:
                    DoOperations.DisplayProducts();
                    break;
                case menuOptions.Exit:
                    break;
                default:
                    Console.WriteLine(" Please Enter valid Input");
                    break;
            }
            if (Convert.ToInt32(uoption) == 6)
            {
                break;
            }
            uoption = ReadUserOption();
        }
        while (Convert.ToInt32(uoption) != 6);
        Console.WriteLine();



    }
    public static menuOptions ReadUserOption()
    {
        menuOptions option = menuOptions.AddStudent;
        do
        {
            Console.WriteLine((int)option + " " + option);

            option++;
        }
        while (option <= menuOptions.Exit);
        Console.WriteLine();
        Console.Write("Select Option From the Above Menu :");
        int userOption = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return (menuOptions)userOption;
    }
}
