using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Week7ProjectWeek.ResourceLibrary.Students
{
    class CollectionS : IEnumerable
    {
        /*

            Dictionary<string,int> students = new Dictionary<sring,int>();
            students.Add("AA",1);
            students.Add("BB",2);
            students.Add("CC",3);
            students.Add("DD",4);
            students.Add("EE",5);
            students.Add("FF",6);

        */

        private Student[] students;

        //Create internal array in constructor.
        public CollectionS()
        {
            students = new Student[6]
            {
            new Student("Amy Apple",1),
            new Student("Betty Blue",2),
            new Student("Chris Collins",3),
            new Student("Joe Jones",4),
            new Student("Matt Martins",5),
            new Student("Susy Student",6),
            };
        }

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

        /*
            enumerator interface allows us to iterate over the collection
            https://support.microsoft.com/en-us/kb/322022
        */


        //private enumerator class
        private class MyEnumerator : IEnumerator
        {
            public Student[] studentlist;
            int position = -1;

            //constructor
            public MyEnumerator(Student[] list)
            {
                studentlist = list;
            }
            private IEnumerator getEnumerator()
            {
                return (IEnumerator)this;
            }


            //IEnumerator
            public bool MoveNext()
            {
                position++;
                return (position < studentlist.Length);
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
                        return studentlist[position];
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
            return new MyEnumerator(students);
        }
    }
    
}
