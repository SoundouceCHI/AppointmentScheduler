namespace Appointment_Scheduler.Models
{
    public class UserProfileViewModel
    {
            public UserApp UserApp { get; set; }
            public IEnumerable<Appointment> Appointments { get; set; }
    }
}
