using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class DVD : Resources
    {
        private List<DVD> dvds;

        public DVD(string newDvd, int newID) : base(newDvd, newID)
        {

        }

        public override void EditFields()
        {
            Console.WriteLine("\tWhich resource do you wish to edit?");
            string resource = Console.ReadLine();
            Console.WriteLine("\tEnter the field you wish to edit:");
            Console.WriteLine("\t1.Title\n\t2.ISBN\n\t3.Length (minutes)");
            int input = int.Parse(Console.ReadLine());
        }

        
    }
}
