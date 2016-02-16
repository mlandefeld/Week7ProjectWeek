using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
 
    class CollectionR : IEnumerable
    {
        private List<Resource> resources;


        public CollectionR()
        {
            List<Resource> resources = new List<Resource>();


            resources.Add(new Resource("ASP.NET MVC 5", 1));
            resources.Add(new Resource("Assembly Language Tutor",2));
            resources.Add(new Resource("C#",3));
            resources.Add(new Resource("C# 5.0 for Dummies",4));
            resources.Add(new Resource("Database Design",5));
            resources.Add(new Resource("Eloquent JavaScript",6));
            resources.Add(new Resource("Essential C# 6.0",7));
            resources.Add(new Resource("JavaScript for Kids",8));
            resources.Add(new Resource("Mastering C Pointers",9));
            resources.Add(new Resource("SQL Queries",10));
            resources.Add(new Resource("The C# Player's Guide",11));

            this.resources = resources;
        }

        public Resource findByTitle(string title)
        {
            return this.resources.Where(c => c.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase)).First();
        }

        public bool hasTitle(string title)
        {
            foreach (Resource resource in this.resources)
            {
                if (resource.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Resource> forStudentId(int student_id)
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

        public List<Resource> available()
        {
            return this.resources.Where(c => c.isAvailable()).ToList();
        }
        

        public IEnumerator GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }
    }
    
}
