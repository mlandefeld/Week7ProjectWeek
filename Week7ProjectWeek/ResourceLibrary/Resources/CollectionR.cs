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
        private List<Book> books;


        public CollectionR()
        {
            List<Book> books = new List<Book>();


            books.Add(new Book("ASP.NET MVC 5", 1));
            books.Add(new Book("Assembly Language Tutor",2));
            books.Add(new Book("C#",3));

            this.books = books;
        }

        public Resources findByTitle(string title)
        {
            return this.books.Where(c => c.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase)).First();
        }

        public bool hasTitle(string title)
        {
            foreach (Resources resource in this.books)
            {
                if (resource.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Book> forStudentId(int student_id)
        {
            return this.books.Where(c => c.student_id == student_id).ToList();
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

        public List<Book> available()
        {
            return this.books.Where(c => c.isAvailable()).ToList();
        }
        

        public IEnumerator GetEnumerator()
        {
            return this.books.GetEnumerator();
        }
    }
    
}
