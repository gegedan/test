using System;
using System.Collections.Generic;
using System.Web.Http;
using VehicleSales.Contracts;
using VehicleSales.Data;
using Serilog;

namespace VehicleSales.Host.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger _logger;
        
        public VehicleController(IVehicleRepository vehicleRepository, ILogger logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
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

            _logger.Information($"Added a new car Id: {car.Id}");
        }

        [HttpPost]
        public void AddBike(Bike bike)
        {
            bike.Id = Guid.NewGuid();

            _vehicleRepository.Add(bike);

            _logger.Information($"Added a new bike Id: {bike.Id}");
        }

        [HttpPost]
        public void UpdateCar(Car car)
        {
            _vehicleRepository.Update(car);

            _logger.Information($"Updated Id: {car.Id}");
        }

        [HttpPost]
        public void UpdateBike(Bike bike)
        {
            _vehicleRepository.Update(bike);

            _logger.Information($"Updated Id: {bike.Id}");
        }
    }
}
