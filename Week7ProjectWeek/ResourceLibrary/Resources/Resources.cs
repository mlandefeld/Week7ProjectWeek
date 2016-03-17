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
        public string isbn = "";
        public string length = "";

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

        public string Title
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

        public bool Available
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

        public string ISBN
        {
            get
            {
                return this.isbn;
            }
            set
            {
                isbn = value;
            }
        }

        public string Length
        {
            get
            {
                return this.length;
            }
            set
            {
                length = value;
            }
        }

        public int? Id
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

        public virtual void EditFields()
        {
            Console.WriteLine("\tWhich resource do you wish to edit?");
            string resource = Console.ReadLine();
            Console.WriteLine("\tEnter the field you wish to edit:");
            Console.WriteLine("\t1.Title\n\t2.ISBN\n\t3.Length (pages)");
            int input = int.Parse(Console.ReadLine());
           
        }

        public virtual void OtherResources()
        {
            Console.WriteLine("Override this in a derived class.");
        }

        public virtual void ThisIsAMethod()
        {
            Console.WriteLine("Override this too.");
        }
    }
}
