using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week7ProjectWeek
{
    //TODO: need to have student files in debug immediately when program is run. 
    //TODO: print message if resource is already checked out or if user is trying to return a resource they did not check out.
    //TODO: If student is trying to check out same book twice, error does not take in other title. 
    //TODO: See line 233 in commands.cs for while looping error. 

    class Program
    {
        static void Main(string[] args)
        {
            

            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            
            Console.Title = "Bootcamp Library Checkout System";
            string s = "Bootcamp Library Checkout System";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            StringBuilder menu = new StringBuilder();
            menu.Append("\n\tMenu: Enter a number to select the corresponding option\n\t");
            menu.Append("1.View Students\n\t");
            menu.Append("2.View Available Resources\n\t");
            menu.Append("3.View Student Accounts\n\t");
            menu.Append("4.Checkout Items\n\t");
            menu.Append("5.Return Items\n\t");
            menu.Append("6.Exit");
            
            Console.WriteLine(menu);
            string input = Console.ReadLine();
            ResourceLibrary.Commands commandInterface = new ResourceLibrary.Commands();
            while (true)
            {
                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    ResourceLibrary.Commands.Exit();
                }
                else if (input == "1")
                {
                    Console.Clear();
                    StringBuilder one = new StringBuilder();
                    one.Append("Bootcamp Library Checkout System");
                    one.Append("\n\n\t\t\tList of Students:\n\t\t\t****************");
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(one);
                    commandInterface.ViewStudents();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;

                }
                else if (input == "2")
                {
                    Console.Clear();
                    StringBuilder two = new StringBuilder();
                    two.Append("Bootcamp Library Checkout System");
                    two.Append("\n\n\t\t\tList of Available Resources:\n\t\t\t***************************");
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(two);
                    commandInterface.ViewAvailableResources();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "3")
                {
                    Console.Clear();
                    StringBuilder three = new StringBuilder();
                    three.Append("Bootcamp Library Checkout System");
                    three.Append("\n\n\t\t\tView Student Accounts:\n\t\t\t**************************");
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(three);
                    commandInterface.ViewStudentAccounts();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "4")
                {
                    Console.Clear();
                    StringBuilder four = new StringBuilder();
                    four.Append("Bootcamp Library Checkout System");
                    four.Append("\n\n\t\t\tCheckout Item:\n\t\t\t***************");
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(four);
                    commandInterface.CheckoutItem();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "5")
                {
                    Console.Clear();
                    StringBuilder five = new StringBuilder();
                    five.Append("Bootcamp Library Checkout System");
                    five.Append("\n\n\t\t\tReturn Item:\n\t\t\t***************");
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(five);
                    commandInterface.ReturnItem();
                    Console.WriteLine(menu);
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "6")
                {
                    ResourceLibrary.Commands.Exit();
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
