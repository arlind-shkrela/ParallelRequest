using ParallelRequest.Models;

namespace ParallelRequest.DTO
{
    public class AppointmentSlotsMetadataResponseDTO
    {
        public List<Location> Locations { get; set; } 
        public List<SessionHolder> SessionHolders { get; set; }
        public List<Sessions> Sessions { get; set; }
    }
}
