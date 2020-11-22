using LimbaBackOfficeData.Enums;

namespace LimbaBackOfficeData.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool ForcePasswordReset { get; set; }
    }
}
