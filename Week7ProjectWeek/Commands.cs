using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week7ProjectWeek.ResourceLibrary
{
    class Commands
    {
        public Students.CollectionS students;
        public Resources.CollectionR resources;

        public Commands()
        {
            students = new Students.CollectionS();
            resources = new Resources.CollectionR();
        }

        public void Dictionary()
        {
            Dictionary<string, int> studentID = new Dictionary<string, int>();
            studentID.Add("Amy Apple", 1);
            studentID.Add("Betty Blue",2);
            studentID.Add("Chris Collins", 3);
            studentID.Add("Joe Jones",4);
            studentID.Add("Matt Martins", 5);
            studentID.Add("Susy Student",6);


        }

        public void WriteStream()
        {
            StreamWriter writer = new StreamWriter("Currently_Checked_Out.txt");

            writer.WriteLine();
        }

        public void ReadStream()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("\n\tMenu: Enter a number to select the corresponding option\n\t");
            menu.Append("1.View Students\n\t");
            menu.Append("2.View Available Resources\n\t");
            menu.Append("3.View Student Accounts\n\t");
            menu.Append("4.Checkout Items\n\t");
            menu.Append("5.Return Items\n\t");
            menu.Append("6.Exit");

            string viewStream = Console.ReadLine();

            while (true)
            {
                if (viewStream == "Yes")
                {
                    Console.Clear();
                    Console.WriteLine(menu);
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    viewStream = Console.ReadLine();
                }
            }

            //how to get checked out resources here? 
            string line;
            using (StreamReader reader = new StreamReader("Currently_Checked_Out.txt"))
            {
                line = reader.ReadLine();
            }
            Console.WriteLine(line);

        }

        public void ViewStudents()
        {
            foreach (Students.Student student in this.students)
            {
                Console.WriteLine("\t\t\t" + student.Name);
            }
        }

        public void ViewAvailableResources()
        {
            List<Resources.Resource> available = this.resources.available();
            if (available.Count == 0)
            {
                Console.WriteLine("\t\t\tAll resources are checked out");
            }
            else
            {
                foreach (Resources.Resource resource in available)
                {
                    Console.WriteLine("\t\t\t" + resource.Title);
                }
            }

            Console.WriteLine("\n\t\tDo you want to view currently checked out resources? \n\t\tEnter \"Yes\" or select a menu item below");

            ReadStream();

        }


        public void ViewStudentAccounts()
        {
            Console.Write("\tEnter Student Name: ");
            string inputName = Console.ReadLine();

            int student_id = 0;

            while (true)
            {
                if (this.students.hasName(inputName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputName = Console.ReadLine();
                }

            }


            foreach (Students.Student student in this.students)
            {

                if (inputName == student.Name)
                {
                    student_id = student.Id;
                }
            }
            if (this.resources.zeroCheckedOut(student_id))
            {
                Console.WriteLine("\n\t\t\tNo resources are checked out to this student.");
            }
            else
            {
                
                List<Resources.Resource> resources = this.resources.forStudentId(student_id);
                foreach (Resources.Resource resource in resources)
                {

                    Console.WriteLine("\t\t" + resource.Title);
                }
            }

        }


        public void CheckoutItem()
        {
            Console.Write("\tEnter Student Name: ");
            string inputName = Console.ReadLine();

            while (true)
            {
                if (this.students.hasName(inputName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputName = Console.ReadLine();
                }

            }

            Console.Write("\tEnter Title of Resource: ");
            string inputTitle = Console.ReadLine();
            while (true)
            {
                if (this.resources.hasTitle(inputTitle))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputTitle = Console.ReadLine();
                }

            }

            int student_id = 0;

            foreach (Students.Student student in this.students)
            {
                if (inputName == student.Name)
                {
                    student_id = student.Id;
                }
            }

            Resources.Resource resource = this.resources.findByTitle(inputTitle);

            if (resource.isAvailable())
            {
                if (this.resources.hasLessThanThree(student_id))
                {
                    resource.checkout(student_id);
                    Console.WriteLine("\n\t\t" + inputName + " checked out " + resource.Title + ".");
                }
                else
                {
                    Console.WriteLine(inputName + " has checked out the max number of resources.");
                }

            }
            else
            {
                Console.WriteLine("\tError: Request Unavailable. Please try again!");
                Console.Write("\t");
                inputTitle = Console.ReadLine();
            }



        }

        public void ReturnItem()
        {
            Console.Write("\tEnter Student Name: ");
            string inputName = Console.ReadLine();

            while (true)
            {
                if (this.students.hasName(inputName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputName = Console.ReadLine();
                }

            }

            Console.Write("\tEnter Title of Resource to Return: ");
            string inputTitle = Console.ReadLine();

            while (true)
            {
                if (this.resources.hasTitle(inputTitle))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputTitle = Console.ReadLine();
                }

            }

            int student_id = 0;

            
            foreach (Students.Student student in this.students)
            {
                if (inputName == student.Name)
                {
                    student_id = student.Id;
                }
            }

            Resources.Resource resource = this.resources.findByTitle(inputTitle);

            if (resource.isCheckedOutBy(student_id))
            {
                resource.checkin();
                Console.WriteLine("\n\t\t" + inputName + " returned " + resource.Title + ".");
            }
            else
            {
                Console.WriteLine("\n\tError: Request Unavailable. Please try again!");
                Console.Write("\t");
                inputTitle = Console.ReadLine();

            }
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("\n\tThank you for using We Can Code IT's Bootcamp Library Checkout System!\n");
            Environment.Exit(0);
        }
    }
}
