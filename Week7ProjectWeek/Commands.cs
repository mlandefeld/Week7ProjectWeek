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

        /* //from polymorphism project
        public List<Resource> resources;

        public Commands()
        {
            List<Resource> objects = new List<Resource>();
            objects.Add(new DVD("DVD Title", 100, 1));
            objects.Add(new Book("Book Title", 200, 2));
            objects.Add(new Magazine("Magazine Title", 300, 3));

            this.resources = objects;
        }

        public List<Resource> Resources
        {
            get { return this.resources; }
        }
        */

        public Commands()
        {
            students = new Students.CollectionS();
            resources = new Resources.CollectionR();
            
            this.WriteStream();
        }

        public void WriteStream()//currently checked out resources
        {
            StreamWriter writer = new StreamWriter(this.resourceFile, false);

            writer.WriteLine();
            writer.Close();
            
        }

        public void ReadStream()//currently checked out resources
        {  
            string viewStream = Console.ReadLine();

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
            
        }

        public void ViewAllResources()
        {
            StreamReader allResources = new StreamReader("All_Resources.txt");
            string line = allResources.ReadToEnd();
            Console.WriteLine(line);
        }

        public void EditResources()
        {

            /*
            Console.WriteLine("\tWhich resource do you wish to edit?");
            string resource = Console.ReadLine();
            Console.WriteLine("\tEnter the field you wish to edit:");
            Console.WriteLine("\t1.Title\n\t2.ISBN\n\t3.Length");
            int input = int.Parse(Console.ReadLine());
            while (true)
            {
                if(input == 1)
                {

                    break;
                }
                else if(input == 2)
                {
                    break;
                }
                else if(input == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tError: Request Unavailable. Please try again!");
                    Console.Write("\t");
                    input = int.Parse(Console.ReadLine());
                }
            }
            */
        }

        public void ViewStudents()
        {
            StreamReader allStudents = new StreamReader("All_Students.txt");
            string line = allStudents.ReadToEnd();
            Console.WriteLine(line);
        }
        
        public void ViewAvailableResources()
        {
            List<Resources.Resources> available = this.resources.available();
            if (available.Count == 0)
            {
                Console.WriteLine("\t\t\tAll resources are checked out");
            }
            else
            {
                foreach (Resources.Resources resource in available)
                {
                    Console.WriteLine("\t\t\t" + resource.Title);
                }
            }
        }

        public void ViewStudentAccounts()
        {
            Console.WriteLine("\t\t\tStudents to choose from:");
            foreach (Students.Student student in this.students)
            {
                Console.WriteLine("\t\t\t" + student.Name);
            }
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
                List<Resources.Resources> resources = this.resources.forStudentId(currentStudent.id);
                foreach (Resources.Resources resource in resources)
                {

                    Console.WriteLine("\tChecked out resource: " + resource.Title);
                }
            }

        }


        public void CheckoutItem()       //error when I input a resouce and it says checked out, but then "Try again!" error
        {
            Console.WriteLine("\t\t\tStudents to choose from:");
            foreach (Students.Student student in this.students)
            {
                Console.WriteLine("\t\t\t" + student.Name);
            }
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

            Console.WriteLine("\t\t\tResources to choose from:");
            foreach (Resources.Resources resources in this.resources)
            {
                Console.WriteLine("\t\t\t" + resources.Title);
            }
            Console.Write("\tEnter Title of Resource to Check Out: ");
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
            Resources.Resources resource = this.resources.findByTitle(inputTitle);

            while (true)
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
            Console.WriteLine("\t\t\tStudents to choose from:");
            foreach (Students.Student student in this.students)
            {
                Console.WriteLine("\t\t\t" + student.Name);
            }
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

            Console.WriteLine("\t\t\tResources to choose from:");
            foreach (Resources.Resources resources in this.resources)
            {
                Console.WriteLine("\t\t\t" + resources.Title);
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


            Students.Student currentStudent = this.students.findByName(inputName);

            Resources.Resources resource = this.resources.findByTitle(inputTitle);
            
            
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
                File.Delete(Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt");
                File.Move(Regex.Replace(currentStudent.Name, @"\s+", "") + "slek.txt", Regex.Replace(currentStudent.Name, @"\s+", "") + ".txt");

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
