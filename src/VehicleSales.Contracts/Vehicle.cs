using System;

namespace VehicleSales.Contracts
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Engine { get; set; }

        public int Wheels { get; set; }
    }
}
