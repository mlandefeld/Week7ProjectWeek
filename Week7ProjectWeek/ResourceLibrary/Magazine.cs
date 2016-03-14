using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class Magazine : Resources
    {

        public Magazine(string newDvd, int newID) : base(newDvd, newID)
        {
            this.id = newID;
            this.title = newDvd;
        }

    }
}
