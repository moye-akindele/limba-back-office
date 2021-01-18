using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IAuthService
    {
        AuthResponse GetAppUserByEmail(string appUserEmail, string password);
        AppUserDTO Create(AppUser appUser);
        bool Reset(string emailAddress);
    }
}
