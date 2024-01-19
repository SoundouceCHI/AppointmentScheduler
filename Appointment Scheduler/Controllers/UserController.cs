﻿using Appointment_Scheduler.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Profile()
        {
            int? id = HttpContext.Session.GetInt32("UserAppId"); 
            if (id == null)
            {
                return RedirectToAction("Index", "Home"); 
            }
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var apptMnt = _context.Appointments.Where(a => a.UserAppId == id).ToList();
            apptMnt = apptMnt == null ? new List<Appointment>() : apptMnt;
            var viewModel = new UserProfileViewModel
            {
                UserApp = user,
                Appointments = apptMnt
            };
            return View(viewModel);
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
                HttpContext.Session.SetInt32("UserAppId", lastId);
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
                return RedirectToAction("Connection", userLog); 
            }

            HttpContext.Session.SetInt32("UserAppId", userLog.Id);
            return RedirectToAction("Profile", new { id = userLog.Id});
        }

        public IActionResult UserLogout()
        {
            HttpContext.Session.Remove("UserAppId");
            return RedirectToAction("Index", "Home"); 
        }

        public IActionResult CreateAppointmentView(int userId)
        {
            var appt = new Appointment();
            appt.UserAppId = userId; 
            return View(appt);
        }
        public IActionResult CreateAppt(Appointment appts)
        {
            if (ModelState.IsValid)
            {
                if (appts.StartDate > appts.EndDate)
                {
                    ModelState.AddModelError("EndDate", "La date de fin doit être après la date de début.");
                    return View("CreateAppointmentView", appts);
                }
                _context.Appointments.Add(appts);
                _context.SaveChanges();
            }
      
            return RedirectToAction("Profile");
        }
    }
}
