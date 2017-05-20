using System;
using System.Web.Mvc;
using VehicleSales.Data;

namespace VehicleSales.Host.Controllers
{
    public class EditVehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public EditVehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public ActionResult Index(Guid Id)
        {
            return View("EditVehicle", _vehicleRepository.GetVehicleById(Id));
        }
    }
}