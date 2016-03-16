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

        }

        public override void ThisIsAMethod()
        {
            Console.WriteLine("These are books.");
        }

    }
}
