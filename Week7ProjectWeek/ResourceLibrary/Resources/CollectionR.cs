using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    /*
    class CollectionR
    {
        
        Dictionary<string, int> resources = new Dictionary<string, int>();
            resources.Add("A",1);
            resources.Add("B",2);
            resources.Add("C",3);
            resources.Add("D",1);
            resources.Add("E",2);
            resources.Add("F",3);
            resources.Add("G",1);
            resources.Add("H",2);
            resources.Add("I",3);
            resources.Add("J",1);
            resources.Add("K",2);
        
    }
    */

    class CollectionR : IEnumerable
    {
        private Resource[] resources;

        //Create internal array in constructor.
        public CollectionR()
        {
            resources = new Resource[11]
            {
            new Resource("ASP.NET MVC 5",1),
            new Resource("Assembly Language Tutor",2),
            new Resource("C#",3),
            new Resource("C# 5.0 for Dummies",4),
            new Resource("Database Design",5),
            new Resource("Eloquent JavaScript",6),
            new Resource("Essential C# 6.0",7),
            new Resource("JavaScript for Kids",8),
            new Resource("Mastering C Pointers",9),
            new Resource("SQL Queries",10),
            new Resource("The C# Player's Guide",11),
            };


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

        public Resource[] forStudentId(int student_id)
        {
            return this.resources.Where(c => c.student_id == student_id).ToArray();
        }

        public bool hasLessThanThree(int student_id)
        {
            if (this.forStudentId(student_id).Length < 3)
            {
                return true;
            }
            return false;
        }

        public bool zeroCheckedOut(int student_id)
        {
            if (this.forStudentId(student_id).Length == 0)
            {
                return true;
            }
            return false;
        }

        public Resource[] available()
        {
            return this.resources.Where(c => c.isAvailable()).ToArray();
        }
        /**
        * enumerator interface allows us to iterate over the collection
        * https://support.microsoft.com/en-us/kb/322022
        **/

        
        //private enumerator class
        private class MyEnumerator : IEnumerator
        {
            public Resource[] resourcelist;
            int position = -1;

            //constructor
            public MyEnumerator(Resource[] list)
            {
                resourcelist = list;
            }
            private IEnumerator getEnumerator()
            {
                return (IEnumerator)this;
            }


            //IEnumerator
            public bool MoveNext()
            {
                position++;
                return (position < resourcelist.Length);
            }

            //IEnumerator
            public void Reset()
            { position = -1; }

            //IEnumerator
            public object Current
            {
                get
                {
                    try
                    {
                        return resourcelist[position];
                    }

                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }  //end nested class

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(resources);
        }
    }
    
}
