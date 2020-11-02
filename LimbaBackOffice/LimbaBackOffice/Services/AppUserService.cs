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
                                  Username = appUser.Username,
                                  UserFirstName = appUser.UserFirstName,
                                  UserLastName = appUser.UserLastName,
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
                Username = appUser.Username,
                UserFirstName = appUser.UserFirstName,
                UserLastName = appUser.UserLastName,
                IsActive = appUser.IsActive
            };

            return appUserDTO;
        }

        public bool Create(AppUser appUser)
        {
            // Decode password from front-end.
            byte[] data = Convert.FromBase64String(appUser.Password);
            string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            PasswordHash hash = new PasswordHash(appUser.Password);
            byte[] hashBytes = hash.ToArray();
            appUser.Password = Convert.ToBase64String(hashBytes);

            return _respository.Create(appUser);
        }

        public bool Update(AppUser appUser)
        {
            // Decode password from front-end.
            byte[] data = Convert.FromBase64String(appUser.Password);
            string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            PasswordHash hash = new PasswordHash(decodedString);
            byte[] hashBytes = hash.ToArray();
            appUser.Password = Convert.ToBase64String(hashBytes);

            return _respository.Update(appUser);
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
                Username = appUser.Username,
                UserFirstName = appUser.UserFirstName,
                UserLastName = appUser.UserLastName,
                IsActive = appUser.IsActive
            };

            return appUserDTO;
        }
    }
}
