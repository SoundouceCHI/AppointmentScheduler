using Appointment_Scheduler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduler.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Registration()
        {
            var userVmo = new UserApp(); 
            return View(userVmo);
        }
        public IActionResult Connection()
        {
            var userVmo = new UserApp();
            return View();
        }
        public IActionResult UserRegistration(UserApp userApp)
        {
            return View("Index");
        }
        public IActionResult UserConnection(UserApp userApp)
        {
            return View("Profile");
        }
    }
}
