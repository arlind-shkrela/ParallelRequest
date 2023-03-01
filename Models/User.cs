namespace ParallelRequest.Models
{
    public class User
    {
        public Guid UserInRoleGuid { get; set; } 
        public string Title { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Organisation { get; set; }
    }
}
