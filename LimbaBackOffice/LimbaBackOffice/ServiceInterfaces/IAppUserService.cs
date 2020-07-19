using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IAppUserService
    {
        List<AppUserDTO> Get();
        AppUserDTO Get(int id);
        bool Create(AppUser seat);
        bool Update(AppUser seat);
        bool Delete(int id);
    }
}
