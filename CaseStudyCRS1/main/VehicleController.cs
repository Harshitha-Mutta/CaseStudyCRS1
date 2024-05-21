using Azure;
using Azure.Core;
using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using CaseStudyCRS1.dao.Services;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.exception;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.main
{
    internal class VehicleController
    {
        static VehicleRepo vrepo= new VehicleRepo();
        static VehicleService vservice= new VehicleService(vrepo);
        static Validate validate=new Validate ();
        public static void VehicleMenuDisplay()
        {
            bool condition = true;
            while(condition)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1.Add a Car\n2.Remove a Car" +
                    "\n3.list Available Cars\n4.List Rented Car" +
                    "\n5.Find CarBy Id\n6.Exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }
                switch(option)
                {
                    case 1:
                        AddCar(vservice);
                        break;
                    case 2:
                        RemoveCar(vservice);
                        break;
                    case 3:
                        ListCars(vservice);
                        break;
                    case 4:
                        ListRentedCars(vservice);
                        break;
                    case 5:
                        FindCarByID(vservice);
                        break;
                    case 6:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice...Please Choose again");
                        break;


                }
            }
        }
        public static void AddCar(VehicleService vservice)
        {
            Console.WriteLine("Enter vehicle ID");
            int vid;
            if (!int.TryParse(Console.ReadLine(), out vid))
            {
                Console.WriteLine("Invalid Vehicle ID. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter Make of the Vehicle");
            string make = Console.ReadLine();
            Console.WriteLine("Enter Model of the car");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Year");
            int year;
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid Year. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter Daily Rate");
            int dailyrate;
            if (!int.TryParse(Console.ReadLine(), out dailyrate))
            {
                Console.WriteLine("Invalid DailyRate. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter Status: Available 1/ NotAvailable 0");
            int status;
            if (!int.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Invalid Status. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter PassengerCapacity");
            int passengerCapacity;
            if (!int.TryParse(Console.ReadLine(), out passengerCapacity))
            {
                Console.WriteLine("Invalid Passenger Capacity. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter Engine Capacity");
            float engineCapacity;
            if (!float.TryParse(Console.ReadLine(), out engineCapacity))
            {
                Console.WriteLine("Invalid Engine Capacity. Please enter a valid number.");
                return;
            }
            
            Vehicle vehicle = new Vehicle(vid,make,model,year,dailyrate,status,passengerCapacity,engineCapacity);
            vservice.AddVehicle(vehicle);
            Console.WriteLine("Vehicle Added Successfully");

        }
        public static void RemoveCar(VehicleService vservice)
        {
            Console.WriteLine("Enter Vehicle ID to delete:");
            int vid;
            if (!int.TryParse(Console.ReadLine(), out vid))
            {
                Console.WriteLine("Invalid Vehicle ID. Please enter a valid number.");
                return;
            }
            try
            {
                if (validate.isCarAvailable(vid) == false)
                {
                    throw new CarNotFoundException("VehicleID Not found");
                }
                vservice.DeleteVehicle(vid);
                Console.WriteLine("Vehicle deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
        public static void ListCars(VehicleService vservice)
        {
            var allVehicles = vservice.ListAvailableCars();
            if (allVehicles == null || !allVehicles.Any())
            {
                Console.WriteLine("No Vehicles found.");
            }
            else
            {
                var table = ConsoleTable.From(allVehicles);
                table.Write();

            }
        }
        public static void ListRentedCars(VehicleService vservice)
        {
            var allVehicles = vservice.ListRentedCars();
            if (allVehicles == null || !allVehicles.Any())
            {
                Console.WriteLine("No Vehicles found.");
            }
            else
            {
                var table = ConsoleTable.From(allVehicles);
                table.Write();

            }
        }
        public static void FindCarByID(VehicleService vservice)
        {
            Console.WriteLine("Enter Vehicle ID ");
            if (!int.TryParse(Console.ReadLine(), out int vehicleid1))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }
            
            var vehicle= vservice.FindCarById(vehicleid1);
            if(vehicle==null)
            {
                Console.WriteLine("Vehicle Not Found");
            }
            Console.WriteLine("vehicleid  Make | Model | year | dailyrate | status | passengerCapacity | engineCapacity ");
            Console.WriteLine(vehicle.vehicleid + " | " + vehicle.make + " | " + vehicle.model +
                        " | " + vehicle.year + " | " + vehicle.dailyrate + " | " + vehicle.status + " | "
                        + vehicle.passengerCapacity + " | " + vehicle.engineCapacity );


        }

    }
}
