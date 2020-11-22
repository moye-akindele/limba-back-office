using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using LimbaBackOfficeShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                                  Password = appUser.Password,
                                  FirstName = appUser.FirstName,
                                  LastName = appUser.LastName,
                                  IsActive = appUser.IsActive
                              };

            return appUserList.ToList();
        }

        public AppUserDTO Get(int id)
        {
            // check if user exists
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
                Password = appUser.Password,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                IsActive = appUser.IsActive
            };

            return appUserDTO;
        }

        public AppUserDTO Create(AppUser appUser)
        {
            // Decode password from front-end.
            byte[] data = Convert.FromBase64String(appUser.Password);
            string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            PasswordHash hash = new PasswordHash(appUser.Password);
            byte[] hashBytes = hash.ToArray();
            appUser.Password = Convert.ToBase64String(hashBytes);

            var createdAppUser = _respository.Create(appUser);

            var appUserDTO = new AppUserDTO()
            {
                Id = createdAppUser.Id,
                Email = createdAppUser.Email,
                Password = createdAppUser.Password,
                FirstName = createdAppUser.FirstName,
                LastName = createdAppUser.LastName,
                IsActive = createdAppUser.IsActive,
                ForcePasswordReset = createdAppUser.IsActive,
            };

            return appUserDTO;
        }

        public AppUserDTO Update(AppUser appUser)
        {
            // Decode password from front-end.
            byte[] data = Convert.FromBase64String(appUser.Password);
            string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            PasswordHash hash = new PasswordHash(decodedString);
            byte[] hashBytes = hash.ToArray();
            appUser.Password = Convert.ToBase64String(hashBytes);

            var updatedAppUser = _respository.Update(appUser);

            var appUserDTO = new AppUserDTO()
            {
                Id = updatedAppUser.Id,
                Email = updatedAppUser.Email,
                Password = updatedAppUser.Password,
                FirstName = updatedAppUser.FirstName,
                LastName = updatedAppUser.LastName,
                IsActive = updatedAppUser.IsActive,
                ForcePasswordReset = updatedAppUser.IsActive,
            };

            return appUserDTO;
        }

        public bool Delete(int id)
        {
            return _respository.Delete(id);
        }

        public AppUserDTO GetAppUserByEmail(string appUserEmail)
        {
            // check if method exists
            var appUser = _respository.GetAppUserByEmail(appUserEmail);
            if (appUser == null)
            {
                return null;
            }

            // Convert to DTO
            var appUserDTO = new AppUserDTO()
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Password = appUser.Password,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                IsActive = appUser.IsActive
            };

            return appUserDTO;
        }
    }
}
