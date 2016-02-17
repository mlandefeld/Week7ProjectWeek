using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Students
{
    class Student
    {
        public string name = "";
        public int id = 0;

        public Student(string inputName, int idnew)
        {
            name = inputName;
            id = idnew;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
