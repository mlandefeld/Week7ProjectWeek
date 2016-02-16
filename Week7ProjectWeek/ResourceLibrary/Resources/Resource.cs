using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7ProjectWeek.ResourceLibrary.Resources
{
    class Resource
    {
        public string title = "";
        public bool available = true;
        public int? id = null;
        public int? student_id = null;

        public Resource(string name, int newID)
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

        /// <summary>
        /// This function assigns the student-id to the resource. Sets availability to false. 
        /// </summary>
        /// <returns>
        /// This function returns true if it succeeds or false if it fails.
        /// </returns>
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

        /// <summary>
        /// This function makes the resource available again. Sets availability to true.
        /// </summary>
        /// <returns>
        /// This function returns true if it succeeds or false if it fails. 
        /// </returns>
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


        /// <summary>
        /// getter and setter for titles
        /// </summary>
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
        /// <summary>
        /// getter and setter for available attribute
        /// </summary>
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

    }
}
