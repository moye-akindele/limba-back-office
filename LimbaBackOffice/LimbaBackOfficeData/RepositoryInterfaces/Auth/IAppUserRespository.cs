using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOfficeData.RepositoryInterfaces
{
    public interface IAppUserRespository
    {
        List<AppUser> Get();
        AppUser Get(int appUserId);
        AppUser Create(AppUser ourAppUser);
        AppUser Update(AppUser ourAppUser);
        bool Delete(int appUserId);
        AppUser GetAppUserByEmail(string appUserEmail);
    }
}
