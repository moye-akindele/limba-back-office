using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IAppUserService
    {
        List<AppUserDTO> Get();
        AppUserDTO Get(int id);
        bool Create(AppUser seat);
        bool Update(AppUser seat);
        bool Delete(int id);
        AppUserDTO GetAppUserByEmail(string appUserEmail);
    }
}
