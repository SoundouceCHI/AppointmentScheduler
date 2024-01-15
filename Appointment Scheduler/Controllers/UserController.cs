using Appointment_Scheduler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduler.Controllers
{
    public class UserController : Controller
    {
        private readonly AppointmentContext _context;

        public UserController(AppointmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            var userVmo = new UserApp(); 
            return View(userVmo);
        }
        [HttpGet]
        public IActionResult Connection()
        {
            var userVmo = new UserApp();
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserApp userApp)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(userApp);
                _context.SaveChanges();
                int lastId = userApp.Id;
                return RedirectToAction("Profile", new { id = lastId } );
            }
            return View("Registration", userApp);
        }

        [HttpPost]
        public IActionResult UserConnection(UserApp userApp)
        {
            var userLog = _context.Users.FirstOrDefault(u => u.UserName == userApp.UserName);
            if (userLog == null || userApp.pwd != userLog.pwd )
            {
                return RedirectToAction("Connection", userApp); 
            }
            return RedirectToAction("Profile", new { id = userLog.Id});
        }
    }
}
