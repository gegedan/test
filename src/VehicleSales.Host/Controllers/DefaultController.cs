using System.Web.Mvc;
using VehicleSales.Data;

namespace VehicleSales.Host.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DefaultController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public ActionResult Index()
        {
            return View(_vehicleRepository.GetAllVehicles());
        }

        public ActionResult Clear()
        {
            _vehicleRepository.Clear();

            return RedirectToAction("Index");
        }
    }
}