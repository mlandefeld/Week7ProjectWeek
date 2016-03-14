using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class DVD : Resources
    {

        public DVD(string newDvd, int newID) : base(newDvd, newID)
        {
            this.id = newID;
            this.title = newDvd;
        }

        public override string Title
        {
            get
            {
                return base.Title;
            }

            set
            {
                base.Title = value;
            }
        }

    }
}
