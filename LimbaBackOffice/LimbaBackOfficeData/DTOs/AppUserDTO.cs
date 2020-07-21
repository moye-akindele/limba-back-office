namespace LimbaBackOfficeData.DTOs
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public bool IsActive { get; set; }
    }
}
