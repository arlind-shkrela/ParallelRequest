using System.Security.Principal;

namespace ParallelRequest.Models
{
    public class Sessions
    {
        public string SessionName { get; set; }
        public int SessionId { get; set; }
        public int LocationId { get; set; }
        public int DefaultDuration { get; set; }
        public string SessionType { get; set; }
        public int NumberOfSlots { get; set; }
        public int[] ClinicianIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
