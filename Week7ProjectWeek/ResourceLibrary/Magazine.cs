using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class Magazine : Resources
    {
        private List<Magazine> magazines;

        public Magazine(string newDvd, int newID) : base(newDvd, newID)
        {
            this.id = newID;
            this.title = newDvd;

            List<Magazine> magazines = new List<Magazine>();
            magazines.Add(new Magazine("Programming for Muggles", 1));
            magazines.Add(new Magazine("C# Celebs", 2));
            magazines.Add(new Magazine("CSS Fashion", 3));

            this.magazines = magazines;
        }

    }
}
