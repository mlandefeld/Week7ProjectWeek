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

        public void writeFile()
        {
            List<string> student = new List<string>();
            student.Add("AA");
            student.Add("BB");
            student.Add("CC");
            student.Add("DD");
            student.Add("EE");
            student.Add("FF");

            StreamWriter writer = new StreamWriter(student+".txt");

        }

        public void readStream()
        {
            string checkedOut = "Currently_Checked_Out";
            string line;
            using (StreamReader reader = new StreamReader(checkedOut+".txt"))
            {
                line = reader.ReadLine();
            }
            Console.WriteLine(line);

        }


        public void viewStudents()
        {
            foreach (Students.Student student in this.students)
            {
                Console.WriteLine("\t\t\t" + student.Name);
            }
        }

        public void viewAvailableResources()
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
        }


        public void viewStudentAccounts()
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
                    Console.WriteLine("\tError: Request Unavailable");
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
                StringBuilder builder = new StringBuilder();
                builder.Append("\n\t\t\t");
                builder.Append("No resources are checked out to this student.");
                Console.WriteLine(builder);
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


        public void checkoutItem()
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
                    Console.WriteLine("\tError: Request Unavailable");
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
                    Console.WriteLine("\tError: Request Unavailable");
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
                Console.WriteLine("\tError: Request Unavailable");
            }



        }

        public void returnItem()
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
                    Console.WriteLine("\tError: Request Unavailable");
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
                    Console.WriteLine("\tError: Request Unavailable");
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
                Console.WriteLine("\n\tError: Request Unavailable");
            }
        }

        public static void exit()
        {
            Console.Clear();
            Console.WriteLine("\n\tThank you for using We Can Code IT's Bootcamp Library Checkout System!\n");
            Environment.Exit(0);
        }
    }
}
