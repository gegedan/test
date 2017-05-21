using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoRhinoMock;
using Rhino.Mocks;
using VehicleSales.Contracts;
using VehicleSales.Data;
using VehicleSales.Host.Controllers;

namespace VehicleSales.Test.Unit.Host.Controllers
{
    [TestFixture]
    public class VehicleControllerTests
    {
        private TestContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestContext();
        }

        [Test]
        public void Add_car_success()
        {
            _context.ArrangeAddCar();

            _context.ActAddCar();

            _context.VerifyAllExpectations();
        }

        [Test]
        public void Add_bike_success()
        {
            _context.ArrangeAddBike();

            _context.ActAddBike();

            _context.VerifyAllExpectations();
        }

        [Test]
        public void Update_car_success()
        {
            _context.ArrangeUpdateCar();

            _context.ActUpdateCar();

            _context.VerifyAllExpectations();
        }

        [Test]
        public void Update_bike_success()
        {
            _context.ArrangeUpdateBike();

            _context.ActUpdateBike();

            _context.VerifyAllExpectations();
        }

        private class TestContext
        {
            private readonly IFixture _fixture;

            private VehicleController _sut;
            private IVehicleRepository _vehicleRepository;
            private Car _car;
            private Bike _bike;

            public TestContext()
            {
                _fixture = new Fixture().Customize(new CompositeCustomization(
                    new AutoRhinoMockCustomization(),
                    new WebApiCustomization<VehicleController>()));
            }

            public void ArrangeAddCar()
            {
                _car = _fixture.Create<Car>();

                _vehicleRepository = _fixture.Freeze<IVehicleRepository>();

                _vehicleRepository.Expect(v => v.Add(
                    Arg<Car>.Matches(c => c.CarType == _car.CarType 
                        && c.Doors == _car.Doors 
                        && c.Wheels == _car.Wheels 
                        && c.Make == _car.Make
                        && c.Model == _car.Model
                        && c.Engine == _car.Engine)))
                    .Repeat
                    .Once();

                _sut = _fixture.Create<VehicleController>();
            }

            public void ArrangeAddBike()
            {
                _bike = _fixture.Create<Bike>();

                _vehicleRepository = _fixture.Freeze<IVehicleRepository>();

                _vehicleRepository.Expect(v => v.Add(
                    Arg<Bike>.Matches(c => c.BikeType == _bike.BikeType
                        && c.Wheels == _bike.Wheels
                        && c.Make == _bike.Make
                        && c.Model == _bike.Model
                        && c.Engine == _bike.Engine)))
                    .Repeat
                    .Once();

                _sut = _fixture.Create<VehicleController>();
            }

            public void ArrangeUpdateCar()
            {
                _car = _fixture.Create<Car>();

                _vehicleRepository = _fixture.Freeze<IVehicleRepository>();

                _vehicleRepository.Expect(v => v.Update(
                    Arg<Car>.Matches(c => c.CarType == _car.CarType
                        && c.Doors == _car.Doors
                        && c.Wheels == _car.Wheels
                        && c.Make == _car.Make
                        && c.Model == _car.Model
                        && c.Engine == _car.Engine)))
                    .Repeat
                    .Once();

                _sut = _fixture.Create<VehicleController>();
            }

            public void ArrangeUpdateBike()
            {
                _bike = _fixture.Create<Bike>();

                _vehicleRepository = _fixture.Freeze<IVehicleRepository>();

                _vehicleRepository.Expect(v => v.Update(
                    Arg<Bike>.Matches(c => c.BikeType == _bike.BikeType
                        && c.Wheels == _bike.Wheels
                        && c.Make == _bike.Make
                        && c.Model == _bike.Model
                        && c.Engine == _bike.Engine)))
                    .Repeat
                    .Once();

                _sut = _fixture.Create<VehicleController>();
            }

            public void ActAddCar()
            {
                _sut.AddCar(_car);
            }

            public void ActAddBike()
            {
                _sut.AddBike(_bike);
            }

            public void ActUpdateCar()
            {
                _sut.UpdateCar(_car);
            }

            public void ActUpdateBike()
            {
                _sut.UpdateBike(_bike);
            }

            public void VerifyAllExpectations()
            {
                _vehicleRepository.VerifyAllExpectations();
            }
        }
    }
}
