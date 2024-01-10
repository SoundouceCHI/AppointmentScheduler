using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduler.Models
{
    public class AppointmentContext : DbContext
    {
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<UserApp> users { get; set; }                                             

        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) {
        
        }
    }
}
