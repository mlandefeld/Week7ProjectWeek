using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week7ProjectWeek
{

    //TODO: Decide what I can get done tomorrow. 
    //TODO: Figure out how to do checkout with students and resources using lists/dictionaries. Does dictionary and ID number still work? 
    //TODO: integrate StringBuilder
    //TODO: Figure out StreamWriter for each student and Reader for current checked out resources. 

    class Program
    {
        static void Main(string[] args)
        {
            /*
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
            */
            Console.Title = "Bootcamp Library Checkout System";
            string s = "Bootcamp Library Checkout System";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            string menu = ("" +
                "\n\tMenu: Enter a number to select the corresponding option\n\t" +
                "1.View Students\n\t" +
                "2.View Available Resources\n\t" +
                "3.View Student Accounts\n\t" +
                "4.Checkout Items\n\t" +
                "5.Return Items\n\t" +
                "6.Exit" +
                "");
            Console.WriteLine(menu);
            string input = Console.ReadLine();
            ResourceLibrary.Commands commandInterface = new ResourceLibrary.Commands();
            while (true)
            {
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    ResourceLibrary.Commands.exit();
                }
                else if (input == "1")
                {
                    Console.Clear();
                    string one = "Bootcamp Library Checkout System \n\n\t\t\tList of Students:\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(one);
                    commandInterface.viewStudents();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;

                }
                else if (input == "2")
                {
                    Console.Clear();
                    string two = "Bootcamp Library Checkout System \n\n\t\t\tList of Available Resources:\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(two);
                    commandInterface.viewAvailableResources();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "3")
                {
                    Console.Clear();
                    string three = "Bootcamp Library Checkout System \n\n\t\t\tView Student Accounts:\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(three);
                    commandInterface.viewStudentAccounts();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "4")
                {
                    Console.Clear();
                    string four = "Bootcamp Library Checkout System \n\n\t\t\tCheckout Item:\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(four);
                    commandInterface.checkoutItem();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "5")
                {
                    Console.Clear();
                    string five = "Bootcamp Library Checkout System \n\n\t\t\tReturn Item:\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(five);
                    commandInterface.returnItem();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "6")
                {
                    ResourceLibrary.Commands.exit();
                }
                else
                {
                    Console.WriteLine("Oops! You need to enter a vaild menu number!");
                    input = Console.ReadLine();
                }
            }
        }
    }
}
