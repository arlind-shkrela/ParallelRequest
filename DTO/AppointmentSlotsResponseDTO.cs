using ParallelRequest.Models;

namespace ParallelRequest.DTO
{
    public class AppointmentSlotsResponseDTO
    {
        public IEnumerable<Sessions> Sessions { get; set; } 
    }
}
