using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using LimbaBackOfficeShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRespository _respository;
        public AuthService(IAppUserRespository respository)
        {
            _respository = respository;
        }

        public AppUserDTO GetAppUserByEmail(string appUserEmail, string password)
        {
            // check if user exists
            var appUser = _respository.GetAppUserByEmail(appUserEmail);
            if (appUser == null)
            {
                return null;
            }

            // Verify password.
            // Decode password from front-end.
            byte[] enteredPassword = Convert.FromBase64String(password);
            string decodedEnteredPassword = Encoding.UTF8.GetString(enteredPassword);

            byte[] storedPassword = Convert.FromBase64String(appUser.Password);
            string decodedstoredPassword = Encoding.UTF8.GetString(enteredPassword);
            

            if ( decodedEnteredPassword != decodedstoredPassword)
            {
                return null;

                // TODO: Reverse any applied password hashing in here.
                //PasswordHash hash = new PasswordHash(hashBytes);
                //if (!hash.Verify(decodedString))
                //{
                //    return null;
                //}
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
            //TODO: Implement password hashing for enterprise level security.
            // Decode password from front-end.
            //byte[] data = Convert.FromBase64String(appUser.Password);
            //string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            //PasswordHash hash = new PasswordHash(decodedString);
            //byte[] hashBytes = hash.ToArray();
            //appUser.Password = Convert.ToBase64String(hashBytes);

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
    }
}
