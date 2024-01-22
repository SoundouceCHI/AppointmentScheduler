using Appointment_Scheduler.Models;

namespace Appointment_Scheduler.Services
{
    public class AppointmentService
    {
        private readonly AppointmentContext _context;

        public AppointmentService(AppointmentContext context)
        {
            _context = context;
        }


        public void DeleteExpiredAppointments()
        {
            var expiredAppointments = _context.Appointments
                .Where(a => a.EndDate < DateTime.Now)
                .ToList();

            foreach (var appt in expiredAppointments)
            {
                _context.Appointments.Remove(appt);
            }
            _context.SaveChanges();
        }

    }
    
}
