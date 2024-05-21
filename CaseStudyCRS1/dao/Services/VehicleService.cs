using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
namespace CaseStudyCRS1.dao.Services
{
    public class VehicleService
    {
        private readonly IVehicle _vehicleRepo;
        public VehicleService(IVehicle vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepo.addCar(vehicle);
        }
        public void DeleteVehicle(int vid)
        {
            _vehicleRepo.removeCar(vid);
        }
        public List<Vehicle> ListAvailableCars()
        {
            return _vehicleRepo.listAvailableCars();
        }
        public List<Vehicle> ListRentedCars()
        {
            return _vehicleRepo.listRentedCars();
        }
        public Vehicle FindCarById(int vid)
        {
            return _vehicleRepo.findCarById(vid);
        }
    }
}
