using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class Magazine : Resources
    {
        private List<Magazine> magazines;

        public Magazine(string newDvd, int newID) : base(newDvd, newID)
        {

        }

        public override void OtherResources()
        {
            Console.WriteLine("This is a magazine.");
        }


    }
}
