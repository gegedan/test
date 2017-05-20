using System;
using System.Collections.Generic;
using VehicleSales.Contracts;

namespace VehicleSales.Data
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicleById(Guid Id);

        ICollection<Vehicle> GetAllVehicles();

        void Add(Vehicle vehicle);

        void Update(Vehicle vehicle);

        void Clear();
    }
}
