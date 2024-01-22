namespace Appointment_Scheduler.Services
{
    public class TimerService : IDisposable, IHostedService
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public TimerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var appointmentService = scope.ServiceProvider.GetRequiredService<AppointmentService>();
                appointmentService.DeleteExpiredAppointments();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
