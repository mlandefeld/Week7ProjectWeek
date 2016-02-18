using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Week7ProjectWeek.ResourceLibrary.Students
{
    class CollectionS : IEnumerable
    {
        

        private List<Student> students;

        
        public CollectionS()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Amy Apple", 1));
            students.Add(new Student("Betty Blue",2));
            students.Add(new Student("Chris Collins",3));
            students.Add(new Student("Joe Jones",4));
            students.Add(new Student("Matt Martins",5));
            students.Add(new Student("Susy Student",6));

            this.students = students;

            foreach (Student student in this.students)
            {
                StreamWriter writer = new StreamWriter(Regex.Replace(student.Name, @"\s+", "") +".txt", false);
                writer.WriteLine("Library System Account Information");
                writer.WriteLine("**********************************");
                writer.WriteLine("Student Name: " + student.Name);
                writer.WriteLine("Student ID: " + student.id);
                writer.WriteLine("Student has checked out: ");
                writer.Close();
            }
            
        }

        //use this instead of student.Name in checkout? 
        public bool hasName(string name)
        {
            foreach (Students.Student student in this.students)
            {
                if (student.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }

            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return this.students.GetEnumerator();
        }

    }

    
}
