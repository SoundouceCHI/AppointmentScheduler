using Appointment_Scheduler.Models;
using System.Net;
using System.Net.Mail;

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
        public void SendMailSendReminderBeforeAppointment()
        {
            /*var systemDate = DateTime.Now.AddDays(1);
            var appts = _context.Appointments
                .Where(a => a.StartDate.Day == systemDate.Day && a.StartDate.Month == systemDate.Month)
                .ToList();*/
            var systemDate = DateTime.Now;
            var appts = _context.Appointments
                .Where(a => a.StartDate.Day == systemDate.Day && a.StartDate.Month == systemDate.Month)
                .ToList();
            if(appts.Count() != 0)
            {
                var user = _context.Users.FirstOrDefault(user => user.Id == appts[0].UserAppId);
                var email = user.Email;
                if (email != null) 
                {
                    using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("solaayii@gmail.com", "pczy vanl uypn igqa");


                        foreach (var appt in appts)
                            {
                                var mailMessage = new MailMessage
                                {
                                    From = new MailAddress("solaayii@gmail.com"),
                                    Subject = "Reminder from appointment scheduler App",
                                    Body = $"<h1>{appt.Title}</h1><p>This is a reminder from appointment scheduler App about your appointment on {appt.StartDate}. </p>", 
                                    IsBodyHtml = true,
                                };
                                mailMessage.To.Add(email);

                                smtpClient.Send(mailMessage);
                            }
                    }
                }
               
            }
        }

    }
    
}
