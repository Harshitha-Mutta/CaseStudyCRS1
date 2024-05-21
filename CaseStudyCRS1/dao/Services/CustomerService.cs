using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.dao.Services
{
    public class CustomerService
    {
        private readonly ICustomer _customerRepo;
        public CustomerService(ICustomer customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public void addCustomer(Customer customer)
        {
            _customerRepo.addCustomer(customer);
        }
        public void removeCustomer(int cid)
        {
            _customerRepo.removeCustomer(cid);
        }
        public Customer findCustomerById(int customerID)
        {
            return _customerRepo.findCustomerById(customerID);
        }
        public List<Customer> listCustomers()
        {
            return _customerRepo.listCustomers();
        }


    }
}
