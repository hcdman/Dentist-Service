using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class DentistM
    {
        public int DentistID { get; set; }
        public string FullName { get; set; }
        public string DentistAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }

        //constructor with no parameters
        public DentistM() { }

        //constructor with id & name
        public DentistM(int id, string name)
        {
            DentistID = id;
            FullName = name;
        }

        //constructor with id, name, address, phone number, birthday
        public DentistM(int id, string name, string address, string phone, string birthday)
        {
            DentistID = id;
            FullName = name;
            DentistAddress = address;
            PhoneNumber = phone;
            Birthday = birthday;
        }
    }
}
