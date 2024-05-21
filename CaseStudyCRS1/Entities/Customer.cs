using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.Entities
{
    public class Customer
    {
        public int customerID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public Customer() { }
        public Customer(int customerID, string firstname, string lastname,
            string email, string phoneNumber)
        {
            this.customerID = customerID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}
