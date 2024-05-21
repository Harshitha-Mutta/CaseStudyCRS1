using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.exception;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ConsoleTables;
using CaseStudyCRS1.dao.Services;

namespace CaseStudyCRS1.main
{
    internal class CustomerController
    {
        static CustomerRepo crepo = new CustomerRepo();
        static CustomerService cservice = new CustomerService(crepo);
        static Validate validate = new Validate();
        public static void CustomerMenuDisplay()
        {
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1.Add a Customer\n2.Remove a Customer" +
                    "\n3.list All Customers" +
                    "\n4.Find CustomerBy Id\n5.Exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        AddCustomer(cservice);
                        break;
                    case 2:
                        RemoveCustomer(cservice);
                        break;
                    case 3:
                        ListCustomers(cservice);
                        break;
                    case 4:
                        FindCustomerByID(cservice);
                        break;
                    case 5:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice...Please Choose again");
                        break;
                }
            }
            
        }
        public static void AddCustomer(CustomerService vservice)
        {
            try
            {
                Console.WriteLine("Enter CustomerID");
                if (!int.TryParse(Console.ReadLine(), out int cid))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }
                Console.WriteLine("Enter FirstName");
                string fn = Console.ReadLine();
                Console.WriteLine("Enter LastName");
                string ln = Console.ReadLine();
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                if (validate.isValidEmail(email) == false)
                {
                    throw new InValidEmailException("Invalid Email address");
                }
                Console.WriteLine("Enter Phone Number");
                string phone = Console.ReadLine();
                Customer customer = new Customer(cid, fn, ln, email, phone);
                cservice.addCustomer(customer);
                Console.WriteLine("Customer added successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void RemoveCustomer(CustomerService vservice)
        {
            Console.WriteLine("Enter CustomerID to Delete");
            int cid;
            if (!int.TryParse(Console.ReadLine(), out cid))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            try
            {
                if (validate.isCustomerAvailable(cid) == false)
                {
                    throw new CarNotFoundException("CustomerID Not found");
                }
                vservice.removeCustomer(cid);
                Console.WriteLine("Customer removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void ListCustomers(CustomerService vservice) 
        {
            var allcustomers = vservice.listCustomers();
            if (allcustomers == null || !allcustomers.Any())
            {
                Console.WriteLine("No Customers found.");
            }
            else
            {
                var table = ConsoleTable.From(allcustomers);
                table.Write();

            }
        }
        public static void FindCustomerByID(CustomerService vservice)
        {
            Console.WriteLine("Enter customerID ");
            if (!int.TryParse(Console.ReadLine(), out int cid))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            var customer = vservice.findCustomerById(cid);
            if (customer == null )
            {
                Console.WriteLine("No Customers found.");
            }
            else
            {
                Console.WriteLine("customerID | firstname | lastname | email | phoneNumber");
                Console.WriteLine(customer.customerID + " | " + customer.firstname + " | " + customer.lastname +
                        " | " + customer.email + " | " + customer.phoneNumber);
            }
        }

    }
}
