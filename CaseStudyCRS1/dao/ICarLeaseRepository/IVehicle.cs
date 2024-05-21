using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.Entities;
namespace CaseStudyCRS1.dao.ICarLeaseRepository
{
    public interface IVehicle
    {
        public void addCar(Vehicle v);
        public void removeCar(int vehicleid);
        public List<Vehicle> listAvailableCars();
        public List<Vehicle> listRentedCars();
        public Vehicle findCarById(int carID);
    }
}
