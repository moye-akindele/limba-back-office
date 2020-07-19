using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRespository _respository;
        public AppUserService(IAppUserRespository respository)
        {
            _respository = respository;
        }

        public List<AppUserDTO> Get()
        {
            var appUsers = _respository.Get();

            var appUserList = from appUser in appUsers
                              select new AppUserDTO()
                              {
                                  Id = appUser.Id,
                                  Email = appUser.Email,
                                  Username = appUser.Username,
                                  UserFirstName = appUser.UserFirstName,
                                  UserLastName = appUser.UserLastName,
                                  IsActive = appUser.IsActive
                              };

            return appUserList.ToList();
        }

        public AppUserDTO Get(int id)
        {
            // check if method exists
            var appUser = _respository.Get(id);
            if (appUser == null)
            {
                return null;
            }

            // Convert to DTO
            var appUserDTO = new AppUserDTO()
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Username = appUser.Username,
                UserFirstName = appUser.UserFirstName,
                UserLastName = appUser.UserLastName,
                IsActive = appUser.IsActive
            };

            return appUserDTO;
        }

        public bool Create(AppUser appUser)
        {
            return _respository.Create(appUser);
        }

        public bool Update(AppUser appUser)
        {
            return _respository.Update(appUser);
        }

        public bool Delete(int id)
        {
            return _respository.Delete(id);
        }
    }
}
