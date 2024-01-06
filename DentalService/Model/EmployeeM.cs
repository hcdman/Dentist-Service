using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class EmployeeM
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string EmployeeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }

        //constructor with no parameters
        public EmployeeM() { }

        //constructor with id & name
        public EmployeeM(int id, string name)
        {
            EmployeeID = id;
            FullName = name;
        }

        //constructor with id, name, address, phone number, birthday
        public EmployeeM(int id, string name, string address, string phone, string birthday)
        {
            EmployeeID = id;
            FullName = name;
            EmployeeAddress = address;
            PhoneNumber = phone;
            Birthday = birthday;
        }
    }
}
