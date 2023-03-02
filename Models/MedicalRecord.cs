using System.Reflection.Metadata;

namespace ParallelRequest.Models
{
    public class MedicalRecord
    {
        public Guid PatientGuid { get; set; }
        public string? Title { get; set; }
        public string? Forenames { get; set; }
        public string? Surname { get; set; }
        public string? Sex { get; set; }
        public string? DateOfBirth { get; set; }
        public IEnumerable<Allergy> Allergies { get; set; }
        public string? Consultations { get; set; }
        public List<Document> Documents { get; set; }
        public string? Immunisations { get; set; }
        public IEnumerable<Medication> Medication { get; set; }
        public string? Problems { get; set; }
        public string? TestResults { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
