using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class Book : Resources
    {
        private List<Book> books;

        public Book(string newDvd, int newID) : base(newDvd, newID)
        {
            this.id = newID;
            this.title = newDvd;

            List<Book> books = new List<Book>();

            books.Add(new Book("ASP.NET MVC 5", 1));
            books.Add(new Book("Assembly Language Tutor", 2));
            books.Add(new Book("C#", 3));

            this.books = books;
        }

    }
}
