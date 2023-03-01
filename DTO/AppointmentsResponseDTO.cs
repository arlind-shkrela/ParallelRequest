using ParallelRequest.Models;

namespace ParallelRequest.DTO
{
    public class AppointmentsResponseDTO
    {
        public DateTime AppointmentsFromDateTime { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<SessionHolder> SessionHolders { get; set; }
        public IEnumerable<Sessions> Sessions { get; set; }
    }
}
