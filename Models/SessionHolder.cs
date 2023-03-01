namespace ParallelRequest.Models
{
    public class SessionHolder
    {
        public int ClinicianId { get; set; }
        public string DisplayName { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Sex { get; set; }
        public string JobRole { get; set; }
        public IEnumerable<Location> Languages { get; set; }
    }
}
