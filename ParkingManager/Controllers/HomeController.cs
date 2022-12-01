using Microsoft.AspNetCore.Mvc;

namespace ParkingManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
