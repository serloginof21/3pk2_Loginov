using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_8
{
    class ContactDataFactory
    {
        public static IContact CreateContactData(string a)
        {
            switch (a)
            {
                case "Students": return new Students();
                case "Specialization": return new Specialization();
                case "College": return new College();
                default:
                    throw new ArgumentException("This dont work(((");
            }
        }
    }
}
