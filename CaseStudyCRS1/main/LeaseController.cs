using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.dao.Services;
using CaseStudyCRS1.exception;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.main
{
    internal class LeaseController
    {
        static LeaseRepo lrepo = new LeaseRepo();
        static LeaseService lservice = new LeaseService(lrepo);
        static CustomerRepo crepo = new CustomerRepo();
        static CustomerService cservice = new CustomerService(crepo);
        static PaymentRepo prepo = new PaymentRepo();
        static PaymentService pservice = new PaymentService(prepo);
        static VehicleRepo vrepo = new VehicleRepo();
        static VehicleService vservice = new VehicleService(vrepo);
        static Validate validate = new Validate();
        public static void LeaseMenuDisplay()
        {
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1.Create Lease\n2.Return Car" +
                    "\n3.List All Active Leases" +
                    "\n4.List Lease History\n5.Exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        AddLease(lservice);
                        break;
                    case 2:
                        ReturnCar(lservice);
                        break;
                    case 3:
                        ListActiveLeases(lservice);
                        break;
                    case 4:
                        ListLeaseHistory(lservice);
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
        public static void AddLease(LeaseService lservice)
        {
            try
            {
                Console.WriteLine("These are the available cars");
                VehicleController.ListCars(vservice);
                Console.WriteLine("Enter CarID");
                if (!int.TryParse(Console.ReadLine(), out int carid))
                {
                    Console.WriteLine("Invalid Vehicle ID. Please choose again.");
                }
                /*if (validate.isCarForRent(carid) == false)
                {
                    throw new CarNotFoundException("Car is Not available");
                }*/
                Console.WriteLine("Enter CustomerID ");
                if (!int.TryParse(Console.ReadLine(), out int cusid))
                {
                    Console.WriteLine("Invalid Customer ID. Please choose again.");
                }
                if (validate.isCustomerAvailable(cusid) == false)
                {
                    Console.WriteLine("Customer is new Customer. First register Customer.");
                    CustomerController.AddCustomer(cservice);
                }
                Console.WriteLine("Enter Start date in the format YYYY/MM/DD");
                string s1=Console.ReadLine();
                int year = Convert.ToInt32(s1.Substring(0, 4));
                int month = Convert.ToInt32(s1.Substring(5, 2));
                int day = Convert.ToInt32(s1.Substring(8, 2));
                DateTime sd1 = new DateTime(year,month, day);
                //Console.WriteLine(sd1.ToLongDateString());
                Console.WriteLine("Enter Last Date in the format YYYY/MM/DD");
                string e1 = Console.ReadLine();
                int year1 = Convert.ToInt32(e1.Substring(0, 4));
                int month1 = Convert.ToInt32(e1.Substring(5, 2));
                int day1 = Convert.ToInt32(e1.Substring(8, 2));
                DateTime ed1 = new DateTime(year1, month1, day1);
                //Console.WriteLine(ed1.ToLongDateString());

                Console.WriteLine("Enter Type: Monthly / Daily");
                string type = Console.ReadLine();
                var lease = lservice.createLease(carid, cusid, sd1, ed1,type);
                if (lease != null)
                {
                    Console.WriteLine("Lease added Successfully");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


        }
        public static void ReturnCar(LeaseService lservice)
        {
            Console.WriteLine("Enter LeaseID to return Car");
            int lid;
            if (!int.TryParse(Console.ReadLine(), out lid))
            {
                Console.WriteLine("Invalid Lease ID. Please enter a valid number.");
                return;
            }
            try
            {
                if (validate.isLeaseAvailable(lid) == false)
                {
                    throw new CarNotFoundException("LeaseID Not found");
                }
                
                lservice.returnCar(lid);
                Console.WriteLine("Would you like to do the payment Yes/ No");
                string input=Console.ReadLine();
                if(input.Equals("Yes")||input.Equals("yes"))
                {
                    PaymentController.RecordPayment(pservice);
                }
                else
                {
                    Console.WriteLine("Customer returned successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ListActiveLeases(LeaseService lservice)
        {
            var leases = lservice.ListActiveLeases();
            if (leases == null || !leases.Any())
            {
                Console.WriteLine("No Leases found.");
            }
            else
            {
                //var table = ConsoleTable.From(leases);
                Console.WriteLine("LeaseID | VehicleID | CustomerID | StartDate | EndDate | Type");
                foreach(var lease in leases)
                {
                    Console.WriteLine(lease.leaseId +" | "+lease.vehicleId+" | "+lease.customerId+" | "+lease.startDate.ToLongDateString()+" | "+lease.endDate.ToLongDateString()+" | "+lease.type);
                }
                //table.Write();

            }
        }
        public static void ListLeaseHistory(LeaseService lservice)
        {
            var leases = lservice.listLeaseHistory();
            if (leases == null || !leases.Any())
            {
                PaymentController.RecordPayment(pservice);
            }
            else
            {
                Console.WriteLine("LeaseID | VehicleID | CustomerID | StartDate | EndDate | Type");
                foreach (var lease in leases)
                {
                    Console.WriteLine(lease.leaseId + " | " + lease.vehicleId + " | " + lease.customerId + " | " + lease.startDate.ToLongDateString() + " | " + lease.endDate.ToLongDateString()+ " | " + lease.type);
                }

            }

        }
    }
}
