using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
 
    class CollectionR : IEnumerable
    {
        private List<Resources> resources;


        public CollectionR()
        {
            List<Resources> resources = new List<Resources>();
            resources.Add(new Book("ASP.NET MVC 5", 1));
            resources.Add(new Book("Assembly Language Tutor",2));
            resources.Add(new Book("C#",3));
            resources.Add(new DVD("A Movie", 4));
            resources.Add(new DVD("Another Movie", 5));
            resources.Add(new DVD("A Different Movie", 6));
            resources.Add(new Magazine("Programming for Muggles", 7));
            resources.Add(new Magazine("C# Celebs", 8));
            resources.Add(new Magazine("CSS Fashion", 9));

            this.resources = resources;

            this.WriteFile();
        }

        public void WriteFile()
        {
            StreamWriter allResources = new StreamWriter("All_Resources.txt");
            foreach (Resources resource in this.resources)
            {
                allResources.WriteLine(resource.Title +" (" + resource.GetType().Name + ")");
            }
            allResources.Close();

            StreamWriter magazine = new StreamWriter("Magazine_Titles.txt");
            magazine.WriteLine("Magazine Titles:");
            magazine.WriteLine("Programming for Muggles");
            magazine.WriteLine("C# Celebs");
            magazine.WriteLine("CSS Fashion");
            magazine.Close();

            StreamWriter dvd = new StreamWriter("DVD_Titles.txt");
            dvd.WriteLine("DVD Titles:");
            dvd.WriteLine("A Movie");
            dvd.WriteLine("Another Movie");
            dvd.WriteLine("A Different Movie");
            dvd.Close();

            StreamWriter book = new StreamWriter("Book_Titles.txt");
            book.WriteLine("Book Titles:");
            book.WriteLine("ASP.NET MVC 5");
            book.WriteLine("Assembly Language Tutor");
            book.WriteLine("C#");
            book.Close();
        }

        public Resources findByTitle(string title)
        {
            return this.resources.Where(c => c.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase)).First();
        }

        public bool hasTitle(string title)
        {
            foreach (Resources resource in this.resources)
            {
                if (resource.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Resources> forStudentId(int student_id)
        {
            return this.resources.Where(c => c.student_id == student_id).ToList();
        }

        public bool hasLessThanThree(int student_id)
        {
            if (this.forStudentId(student_id).Count < 3)
            {
                return true;
            }
            return false;
        }

        public bool zeroCheckedOut(int student_id)
        {
            if (this.forStudentId(student_id).Count == 0)
            {
                return true;
            }
            return false;
        }

        public List<Resources> available()
        {
            return this.resources.Where(c => c.isAvailable()).ToList();
        }

        public List<Resources> ToList()
        {
            return this.resources.ToList();
        }
        

        public IEnumerator GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }
    }
    
}
