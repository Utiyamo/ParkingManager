using Microsoft.AspNetCore.Mvc;
using ParkingManager.ViewModels;

namespace ParkingManager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BtnLogin(LoginViewModel model)
        {
            string username = model.Username;
            return View();
        }
    }
}
