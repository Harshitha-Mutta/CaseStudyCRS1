using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.exception;
using CaseStudyCRS1.Entities;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using CaseStudyCRS1.dao.Services;

namespace CaseStudyCRS1.main
{
    internal class PaymentController
    {
        
        static LeaseRepo lrepo = new LeaseRepo();
        static LeaseService lservice = new LeaseService(lrepo);
        static PaymentRepo prepo = new PaymentRepo();
        static PaymentService pservice = new PaymentService(prepo);
        static VehicleRepo vrepo = new VehicleRepo();
        static VehicleService vservice = new VehicleService(vrepo);

        static Validate val = new Validate();
        public static void PaymentMenuDisplay()
        {
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1.Record Payment\n2.List Payment History\n3.Exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        RecordPayment(pservice);
                        break;
                    case 2:
                        ListPaymentHistory(pservice);
                        break;
                    case 3:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice...Please Choose again");
                        break;
                }
            }
        }
        public static void RecordPayment(PaymentService pservice)
        {
            try
            {
                Console.WriteLine("Enter LeaseID");
                if (!int.TryParse(Console.ReadLine(), out int lid))
                {
                    Console.WriteLine("Invalid Lease ID. Please choose again.");
                }
                if(val.isLeaseAvailable(lid)==false)
                {
                    throw new LeaseNotFound();
                }
                Lease lease = lservice.findLeaseByID(lid);
                int vehicleid = lease.vehicleId;
                if (lease == null)
                {
                    Console.WriteLine("No lease assoiated with this lease ID");
                }
                string type = lease.type;
                Vehicle vehicle = vservice.FindCarById(vehicleid);
                TimeSpan d1=lease.endDate-lease.startDate;
                int days = d1.Days + 1;
                float amount = (days) * (vehicle.dailyrate);
                if (type.Equals("Monthly") && days>=10)
                {
                    amount = 0.9f * amount;
                }
                
                Console.WriteLine("Total days = {0},StartDate = {1} , enddate = {2}" , days
                    , lease.startDate.ToLongDateString(), lease.endDate.ToLongDateString());
                Console.WriteLine("Total Amount = "+ amount);
                Console.WriteLine("Please do the payment:1.Yes 2.No");
                int request = Convert.ToInt32(Console.ReadLine());
                if(request == 0)
                {
                    Console.WriteLine("Paymnet Unsuccessful");
                }
                else
                {
                    pservice.recordPayment(lease, amount);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        public static void ListPaymentHistory(PaymentService pservice)
        {
            var payment = pservice.ListPaymentHistory();
            if (payment == null || !payment.Any())
            {
                Console.WriteLine("No Payments found.");
            }
            else
            {
                // var table = ConsoleTable.From(payment);
                //table.Write();
                Console.WriteLine("LeaseId | PaymentDate  |  Amount");

                foreach(var pay in payment)
                {
                    Console.WriteLine(pay.leaseId+" | "+pay.paymentDate.ToLongDateString()+" | "+pay.amount);
                }
         

            }
        }
    }
}
