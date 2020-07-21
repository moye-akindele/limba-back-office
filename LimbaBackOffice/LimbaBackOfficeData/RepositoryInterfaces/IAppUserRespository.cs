using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOfficeData.RepositoryInterfaces
{
    public interface IAppUserRespository
    {
        List<AppUser> Get();
        AppUser Get(int appUserId);
        bool Create(AppUser ourAppUser);
        bool Update(AppUser ourAppUser);
        bool Delete(int appUserId);
        AppUser GetAppUserByEmail(string appUserEmail);
    }
}
