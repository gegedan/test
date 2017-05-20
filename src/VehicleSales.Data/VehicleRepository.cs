using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSales.Contracts;

namespace VehicleSales.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> _vehicles;

        public VehicleRepository()
        {
            Seed();
        }

        public Vehicle GetVehicleById(Guid Id)
        {
            return _vehicles.FirstOrDefault(v => v.Id == Id);
        }

        public ICollection<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public void Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Update(Vehicle vehicle)
        {
            var updatingVehicle = _vehicles.Where(v => v.Id == vehicle.Id).FirstOrDefault();

            updatingVehicle.Make = vehicle.Make;
            updatingVehicle.Engine = vehicle.Engine;
            updatingVehicle.Model = vehicle.Model;
            updatingVehicle.Wheels = vehicle.Wheels;

            if(updatingVehicle is Car)
            {
                ((Car)updatingVehicle).Doors = ((Car)vehicle).Doors;
                ((Car)updatingVehicle).CarType = ((Car)vehicle).CarType;
            }
            else if(updatingVehicle is Bike)
            {
                ((Bike)updatingVehicle).BikeType = ((Bike)vehicle).BikeType;
            }
        }

        public void Clear()
        {
            Seed();
        }

        private void Seed()
        {
            _vehicles = new List<Vehicle>()
            {
                new Car
                {
                    Id = Guid.NewGuid(),
                    Make = "BMW",
                    Model = "X1",
                    Engine = "2.0",
                    Doors = 4,
                    Wheels = 4,
                    CarType = CarType.Hatchback
                },
                new Bike
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "200",
                    Engine = "1000cc",
                    Wheels = 2,
                    BikeType = BikeType.Road
                }
            };
        }
    }
}
