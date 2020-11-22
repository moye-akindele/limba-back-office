using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IAppUserService
    {
        List<AppUserDTO> Get();
        AppUserDTO Get(int id);
        AppUserDTO Create(AppUser seat);
        AppUserDTO Update(AppUser seat);
        bool Delete(int id);
        AppUserDTO GetAppUserByEmail(string appUserEmail);
    }
}
