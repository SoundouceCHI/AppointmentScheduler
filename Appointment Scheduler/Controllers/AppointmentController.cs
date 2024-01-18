using Appointment_Scheduler.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Appointment_Scheduler.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentContext _context;
        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]
        public IEnumerable<Appointment> GetAll()
        {
            IEnumerable<Appointment> objList = _context.Appointments.ToList();

            try
            {
               // IEnumerable<Appointment> objList = _context.Appointments.ToList();
       
            }
            catch (Exception ex)
            {
                
            }
            if(!objList.Any())
            {
                objList = Enumerable.Empty<Appointment>();
            }
            else
            {

            }

            return objList;
        }

        [HttpGet]
        public IActionResult GetAllById(int id)
        {
            IEnumerable<Appointment> objList = _context.Appointments.Where(a=> a.UserAppId == id).ToList();
            return View(objList);
        }


        public IActionResult Appointment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int userId)
        {
            Appointment app = new Appointment();
            app.UserAppId = userId;
            return View(app);
        }
        
        [HttpPost]
        public IActionResult Post(Appointment appointmentModl)
        {
            _context.Appointments.Add(appointmentModl);
            _context.SaveChanges();
            return RedirectToAction("GetAllById", new { id = appointmentModl.UserAppId });

        }
        public IActionResult Index()
        {
            return View();
        }*/
    }
}
