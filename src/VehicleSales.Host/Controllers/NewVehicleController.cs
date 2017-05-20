using System.Web.Mvc;

namespace VehicleSales.Host.Controllers
{
    public class NewVehicleController : Controller
    {
        public ActionResult NewCar()
        {
            return View("NewCar");
        }

        public ActionResult NewBike()
        {
            return View("NewBike");
        }
    }
}