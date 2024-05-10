using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator;

public enum MenuOption
{
    Addition=1,
    Subtraction,
    Multiplication,
    Division,
    Exit
}
internal class Menu
{
    static Calculations calculations = new Calculations();
    public void UserOption()
    {
        
        MenuOption userOption = ReadUserOption();
        do
        {
            switch (userOption)
            {
                case MenuOption.Addition:
                    calculations.Addition();
                    Continue(userOption);
                    break;
                case MenuOption.Subtraction:
                    calculations.Subtraction();
                    Continue(userOption);
                    break;
                case MenuOption.Multiplication:
                    calculations.Multiplication();
                    Continue(userOption);
                    break;
                case MenuOption.Division:
                    calculations.Division();
                    Continue(userOption);
                    break;
                case MenuOption.Exit:
                    break;
                default:
                    Console.WriteLine(" Please Enter valid Input");
                    break;
            }
            if (Convert.ToInt32(userOption) == 5)
            {
                break;
            }
            userOption = ReadUserOption();
        }
        while (Convert.ToInt32(userOption) != 5);
        Console.WriteLine();
    }
    public static MenuOption ReadUserOption()
    {
        MenuOption option = MenuOption.Addition;
        do
        {
            Console.WriteLine($"{(int)option}  {option}");

            option++;
        }
        while (option <= MenuOption.Exit);
        Console.WriteLine();
        Console.Write("Select Option From the Above Menu :");
        int userOption = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return (MenuOption)userOption;
    }

    public static void Continue(MenuOption option)
    {
        Console.WriteLine("Would you Like to continue same Operation Y/N :");
        char c = Convert.ToChar(Console.ReadLine());
        if(c == 'Y')
        {
            do
            {
                switch (option)
                {
                    case MenuOption.Addition:
                        calculations.Addition();
                        break;
                    case MenuOption.Subtraction:
                        calculations.Subtraction();
                        break;
                    case MenuOption.Multiplication:
                        calculations.Multiplication();
                        break;
                    case MenuOption.Division:
                        calculations.Division();
                        break;
                }
                Console.WriteLine("Would you Like to continue same Operation Y/N :");
                c = Convert.ToChar(Console.ReadLine());

            }
            while (c != 'N');
        }
        Console.WriteLine();
    }
}
