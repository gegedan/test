using System;
using System.Collections.Generic;
using System.Web.Http;
using VehicleSales.Contracts;
using VehicleSales.Data;

namespace VehicleSales.Host.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleRepository _vehicleRepository;
        
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleRepository.GetAllVehicles();
        }

        [HttpPost]
        public void AddCar(Car car)
        {
            car.Id = Guid.NewGuid();

            _vehicleRepository.Add(car);
        }

        [HttpPost]
        public void AddBike(Bike bike)
        {
            bike.Id = Guid.NewGuid();

            _vehicleRepository.Add(bike);
        }

        [HttpPost]
        public void UpdateCar(Car car)
        {
            _vehicleRepository.Update(car);
        }

        [HttpPost]
        public void UpdateBike(Bike bike)
        {
            _vehicleRepository.Update(bike);
        }
    }
}
