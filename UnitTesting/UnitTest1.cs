global using NUnit.Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.exception;
using CaseStudyCRS1;
using Microsoft.Playwright;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using CaseStudyCRS1.dao.Services;

namespace UnitTesting
{

    [TestFixture]
    public class Tests
    {
        
        internal class UnitTesting
        {
            static VehicleRepo vrepo = new VehicleRepo();
            static VehicleService vservice = new VehicleService(vrepo);
            static CustomerRepo crepo= new CustomerRepo();
            static CustomerService cservice = new CustomerService(crepo);
            static LeaseRepo lrepo = new LeaseRepo();
            static LeaseService lservice = new LeaseService(lrepo);

            Validate val = new Validate();
            [Test]
            public void CarAdding()
            {
                Vehicle testVehicle = new Vehicle()
                {
                    vehicleid = 1200,
                    make = "BMW",
                    model = "X1",
                    year = 2022,
                    dailyrate = 100,
                    status = 0,
                    passengerCapacity = 7,
                    engineCapacity = 2000

                };
                List<Vehicle> vehicles = vservice.ListAvailableCars();
                int c = vehicles.Count;
                vservice.AddVehicle(testVehicle);
                List<Vehicle> vehiclesAfterAdding = vservice.ListAvailableCars();
                int AfterAdding = vehicles.Count;
                Console.WriteLine(c + " " + AfterAdding);

                Assert.That(AfterAdding, Is.EqualTo(c));
            }
            [Test]
            public void CustomerAdding()
            {
                Customer customer = new Customer()
                {
                    customerID = 18004,
                    firstname = "Samantha",
                    lastname = "Prabhu",
                    email = "hars@gmail.com",
                    phoneNumber = "1234567890"
                };
                List<Customer> l1 = cservice.listCustomers();
                int c = l1.Count;
                cservice.addCustomer(customer);
                List<Customer> l2 = cservice.listCustomers();
                int c2 = l2.Count;
                Console.WriteLine(c + " " + c2);
                Assert.That(c+1, Is.EqualTo(c2));

            }
            [Test]
            public void LeaseAdding()
            {

                int vehicleId = 2;
                int customerId = 3;
                DateTime startDate = Convert.ToDateTime("2024-01-01");
                DateTime endDate = Convert.ToDateTime("2024-01-02");
                string type = "Daily";

                List<Lease> l1 = lservice.listLeaseHistory();
                int c = l1.Count;
                lservice.createLease(vehicleId, customerId, startDate, endDate, type);
                List<Lease> l2 = lservice.listLeaseHistory();
                int c2 = l2.Count;
                Console.WriteLine(c + " " + c2);

                Assert.That(c+2 , Is.EqualTo(c2));

            }
            /*[Test]
            public void carId()
            {
                int cid = 10001;
                bool flag = val.isCarAvailable(cid);
                Assert.That(false, Is.EqualTo(flag));
            }

            [Test]
            public void LeaseId()
            {
                int lid = 10001;
                bool flag = val.isLeaseAvailable(lid);
                Assert.That(false, Is.EqualTo(flag));

            }
            [Test]
            public void CustomerId()
            {
                int lid = 10001;
                bool flag = val.isCustomerAvailable(lid);
                Assert.That(false, Is.EqualTo(flag));

            }*/

        }
    }
}
