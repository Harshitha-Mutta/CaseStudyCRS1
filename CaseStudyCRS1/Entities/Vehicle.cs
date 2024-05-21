using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.Entities
{
    public class Vehicle
    {
        public int vehicleid { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int dailyrate { get; set; }
        public int status { get; set; }
        public int passengerCapacity { get; set; }

        public float engineCapacity { get; set; }
        public Vehicle() { }
        public Vehicle(int vehicleid, string make, string model,
            int year, int dailyrate, int status, int passengerCapacity,float engineCapacity)
        {
            this.vehicleid = vehicleid;
            this.make = make;
            this.model = model;
            this.year = year;
            this.dailyrate = dailyrate;
            this.status = status;
            this.passengerCapacity = passengerCapacity;
            this.engineCapacity = engineCapacity;
            
        }
    }
}
