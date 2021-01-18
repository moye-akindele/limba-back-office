using LimbaBackOfficeData.DTOs;

namespace LimbaBackOfficeData.Models.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public AppUserDTO AppUser { get; set; }
    }
}
