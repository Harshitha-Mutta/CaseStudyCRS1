using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.Entities;
namespace CaseStudyCRS1.dao.ICarLeaseRepository
{
    public interface ICustomer
    {
        public void addCustomer(Customer customer);
        public void removeCustomer(int cid);
        public List<Customer> listCustomers();
        public Customer findCustomerById(int customerID);

    }
}
