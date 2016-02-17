using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Week7ProjectWeek.ResourceLibrary
{
    class Commands
    {
        public Students.CollectionS students;
        public Resources.CollectionR resources;
        public string resourceFile = "Currently_Checked_Out.txt";

        public Commands()
        {
            students = new Students.CollectionS();
            resources = new Resources.CollectionR();
            
            this.WriteStream();
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
            StreamWriter writer = new StreamWriter(this.resourceFile, false);

            writer.WriteLine();
            writer.Close();
        }

        public void ReadStream()
        {

            string viewStream = Console.ReadLine();

            while (true)
            {
                if (viewStream == "Yes")
                {
                    Console.Clear();
                    string line;
                    using (StreamReader reader = new StreamReader(this.resourceFile))
                    {
                        line = reader.ReadLine();
                    }
                    Console.WriteLine(line);
                    break;
                }
                else if (viewStream == "No")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    viewStream = Console.ReadLine();
                }
            }
            

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

            Console.WriteLine("\n\t\tDo you want to view currently checked out resources? \n\t\tEnter \"Yes\" or \"No\"");

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

            Students.Student currentStudent = null;

            foreach (Students.Student student in this.students)
            {
                if (inputName == student.Name)//TODO: make this case insensitive
                {
                    currentStudent = student;
                }
            }

            //get student names here to student.Name below can be used

            Resources.Resource resource = this.resources.findByTitle(inputTitle);

            if (resource.isAvailable())
            {
                if (this.resources.hasLessThanThree(currentStudent.id))
                {
                    resource.checkout(currentStudent.id);
                    StreamWriter writer = new StreamWriter(this.resourceFile, true);
                    writer.WriteLine(resource.Title);
                    writer.Close();

                    StreamWriter writerStudent = new StreamWriter(Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt", true);
                    writerStudent.WriteLine(resource.Title);
                    writerStudent.Close();

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
