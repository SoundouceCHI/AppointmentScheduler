using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduler.Models
{
    public class AppointmentContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserApp> Users { get; set; }                                             

        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) {
        
        }
    }
}
