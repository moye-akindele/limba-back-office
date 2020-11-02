using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IAuthService
    {
        AppUserDTO GetAppUserByEmail(string appUserEmail, string password);

        bool Create(AppUser appUser);
    }
}
