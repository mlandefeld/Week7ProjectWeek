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

        public void StudentDictionary()
        {
            Dictionary<int, string> nameList = new Dictionary<int, string>();
            nameList.Add(1,"Amy Apple");
            nameList.Add(2, "Betty Blue");
            nameList.Add(3, "Chris Collins");
            nameList.Add(4, "Joe Jones");
            nameList.Add(5, "Matt Martins");
            nameList.Add(6, "Susy Student");

            Console.WriteLine("\tEnter a name from the following list: ");
            foreach(string value in nameList.Values)
            {
                Console.WriteLine("\t" +value);
            }
            Console.WriteLine("\t******************************************");

        }

        public void ResourceDictionary()
        {
           Dictionary<int, string> titleList = new Dictionary<int, string>();
            titleList.Add(1, "ASP.NET MVC 5");
            titleList.Add(2, "Assembly Language Tutor");
            titleList.Add(3, "C#");
            titleList.Add(4, "C# 5.0 for Dummies");
            titleList.Add(5, "Database Design");
            titleList.Add(6, "Eloquent JavaScript");
            titleList.Add(7, "Essential C# 6.0");
            titleList.Add(8, "JavaScript for Kids");
            titleList.Add(9, "Mastering C Pointers");
            titleList.Add(10, "SQL Queries");
            titleList.Add(11, "The C# Player's Guide");

            Console.WriteLine("\tEnter a title from the following list: ");
            foreach (string value in titleList.Values)
            {
                Console.WriteLine("\t" + value);
            }
            Console.WriteLine("\t******************************************");

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
                if (viewStream.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("Library Resources Currently Checked Out:");
                    string line;
                    StreamReader reader = new StreamReader(this.resourceFile);
                    using (reader)
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = reader.ReadLine();
                        }
                    }
   
                    Console.WriteLine(line);
                    break;
                }
                else if (viewStream.Equals("No", StringComparison.CurrentCultureIgnoreCase))
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

            Console.Write("\n\t\tDo you want to view currently checked out resources? \n\t\tEnter \"Yes\" or \"No\": ");
            ReadStream();

        }


        public void ViewStudentAccounts()
        {
            StudentDictionary();
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
                //make case insensitive?
                if (inputName == student.Name)//inputName.Equals(student.Name,StringComparison.CurrentCulture)
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

                    Console.WriteLine("\tChecked out resource: " + resource.Title);
                }
            }

        }


        public void CheckoutItem()
        {
            StudentDictionary();
            Console.Write("\tEnter Student Name: ");
            string inputName = Console.ReadLine();

            while (true)
            {
                if (this.students.hasName(inputName))//ignore case problem here? 
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

           // ResourceDictionary();
            Console.Write("\tEnter Title of Resource: ");
            string inputTitle = Console.ReadLine();
            while (true)
            {
                if (this.resources.hasTitle(inputTitle))//inputName.Equals(student.Name, StringComparison.CurrentCultureIgnoreCase)
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
                if (inputName == student.Name)
                {
                    currentStudent = student;
                }
            }

            Resources.Resource resource = this.resources.findByTitle(inputTitle);

            if (resource.isAvailable())
            {
                if (this.resources.hasLessThanThree(currentStudent.id))//ignore case error here
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
                if (this.students.hasName(inputName))//ignore case problem here?
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
                if (this.resources.hasTitle(inputTitle))//ignore case problem here?
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
                if (inputName == student.Name)//ignore case problem here?
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
            Console.WriteLine("\nThank you for using We Can Code IT's Bootcamp Library Checkout System!\n");
            Environment.Exit(0);
        }
    }
}
