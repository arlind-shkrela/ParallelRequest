using ParallelRequest.Models;

namespace ParallelRequest.DTO
{
    public class MedicalRecordResponseDTO
    {
        public MedicalRecord MedicalRecord { get; set; }
        public FilterDetail FilterDetails { get; set; }
    }
}
