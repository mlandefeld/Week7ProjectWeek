using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    abstract class Resources
    {
        public string title = "";
        public bool available = true;
        public int? id = null;
        public int? student_id = null;

        public Resources(string name, int newID)
        {
            this.id = newID;
            this.title = name;
        }

        public bool isCheckedOutBy(int studentid)
        {
            return this.student_id == studentid;
        }

        public bool isAvailable()
        {
            return available;
        }

        public bool checkout(int studentid)
        {
            try
            {
                student_id = studentid;
                available = false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool checkin()
        {
            try
            {
                student_id = null;
                available = true;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public virtual string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                title = value;
            }
        }

        public virtual bool Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }

        public virtual int? Id
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
