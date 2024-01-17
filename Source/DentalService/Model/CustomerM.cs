using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalService.Model
{
    public class CustomerM
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }

        //constructor with no parameters
        public CustomerM() { }

        //constructor with id & name
        public CustomerM(int id, string name, DateTime birthday, string phoneNumber)
        {
            CustomerID = id;
            FullName = name;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
        }

        //constructor with id, name, address, phone number, birthday
        public CustomerM(int id, string name, string address, string phone, DateTime birthday)
        {
            CustomerID = id;
            FullName = name;
            CustomerAddress = address;
            PhoneNumber = phone;
            Birthday = birthday;
        }
    }
}
