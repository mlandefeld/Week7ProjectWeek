using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class DVD : Resources
    {
        private List<DVD> dvds;

        public DVD(string newDvd, int newID) : base(newDvd, newID)
        {
            this.id = newID;
            this.title = newDvd;

            List<DVD> dvds = new List<DVD>();
            dvds.Add(new DVD("A Movie", 1));
            dvds.Add(new DVD("Another Movie", 2));
            dvds.Add(new DVD("A Different Movie", 3));

            this.dvds = dvds;
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
