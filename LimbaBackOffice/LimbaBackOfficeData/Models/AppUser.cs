using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public bool IsActive { get; set; }
    }
}
