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
            Dictionary<int, string> studentName = new Dictionary<int, string>();
            studentName.Add(1,"Amy Apple");
            studentName.Add(2, "Betty Blue");
            studentName.Add(3, "Chris Collins");
            studentName.Add(4, "Joe Jones");
            studentName.Add(5, "Matt Martins");
            studentName.Add(6, "Susy Student");

            Console.WriteLine("\tEnter a name from the following list: ");
            foreach(string value in studentName.Values)
            {
                Console.WriteLine("\t" +value);
            }
            Console.WriteLine("\t******************************************");

        }

        public void ResourceDictionary()
        {
           Dictionary<int, string> titleName = new Dictionary<int, string>();
            titleName.Add(1, "ASP.NET MVC 5");
            titleName.Add(2, "Assembly Language Tutor");
            titleName.Add(3, "C#");
            titleName.Add(4, "C# 5.0 for Dummies");
            titleName.Add(5, "Database Design");
            titleName.Add(6, "Eloquent JavaScript");
            titleName.Add(7, "Essential C# 6.0");
            titleName.Add(8, "JavaScript for Kids");
            titleName.Add(9, "Mastering C Pointers");
            titleName.Add(10, "SQL Queries");
            titleName.Add(11, "The C# Player's Guide");

            Console.WriteLine("\t******************************************");
            Console.WriteLine("\tEnter a title from the following list: ");
            foreach (string value in titleName.Values)
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
                    string s = "Bootcamp Library Checkout System";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.WriteLine("\n\tLibrary Resources Currently Checked Out:");
                    string line;
                    StreamReader reader = new StreamReader(this.resourceFile);
                    using (reader)
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine("\t" +line);
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


            Students.Student currentStudent = this.students.findByName(inputName);

            if (this.resources.zeroCheckedOut(currentStudent.id))
            {
                Console.WriteLine("\n\t\t\tNo resources are checked out to this student.");
            }
            else
            {
                
                List<Resources.Resource> resources = this.resources.forStudentId(currentStudent.id);
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

            ResourceDictionary();
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

            Students.Student currentStudent = this.students.findByName(inputName);
            Resources.Resource resource = this.resources.findByTitle(inputTitle);

            while (true)//error does not loop. is this the wrong place to loop?
            {
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
                        Console.WriteLine("\t" + inputName + " has checked out the max number of resources.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    inputTitle = Console.ReadLine();
                }
            }

        }

        public void ReturnItem()
        {
            StudentDictionary();
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

            ResourceDictionary();
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


            Students.Student currentStudent = this.students.findByName(inputName);

            Resources.Resource resource = this.resources.findByTitle(inputTitle);
            
            
            if (this.resources.zeroCheckedOut(currentStudent.id))
            {
                Console.WriteLine("\n\t\t\tNo resources are checked out to this student.");

            }
            else if (resource.isCheckedOutBy(currentStudent.id))
            {
                resource.checkin();

                string line = null;
                using (StreamReader reader = new StreamReader(this.resourceFile))
                {
                    using (StreamWriter writer = new StreamWriter(this.resourceFile + "sdf.txt"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (String.Compare(line, resource.Title) == 0)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }
                File.Delete(this.resourceFile);
                File.Move(this.resourceFile + "sdf.txt", this.resourceFile);

                using (StreamReader reader = new StreamReader(Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt"))
                {
                    using (StreamWriter writer = new StreamWriter(Regex.Replace(currentStudent.Name, @"\s+", "") + "slek.txt"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (String.Compare(line, resource.Title) == 0)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }
                System.IO.File.Delete(Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt");
                System.IO.File.Move(Regex.Replace(currentStudent.Name, @"\s+", "") + "slek.txt", Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt");

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
