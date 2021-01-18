using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Models.Auth;
using LimbaBackOfficeData.RepositoryInterfaces;
using LimbaBackOfficeShared;
using LimbaBackOfficeShared.Models;
using LimbaBackOfficeShared.NotificationEmail;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRespository _respository;
        public IConfiguration Configuration { get; }
        public AuthService(IAppUserRespository respository, IConfiguration configuration)
        {
            _respository = respository;
            Configuration = configuration;
        }

        public AuthResponse GetAppUserByEmail(string appUserEmail, string password)
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

            // Decode stored password from UTF8 to bytes.
            byte[] hashBytes = Convert.FromBase64String(appUser.Password);
            PasswordHash hash = new PasswordHash(hashBytes);

            if (!hash.Verify(decodedEnteredPassword))
            {
                return null;
            } else {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var baseUrl = Configuration["Data:BaseUrl"];

                var tokenOptions = new JwtSecurityToken(
                    issuer: baseUrl,
                    audience: baseUrl,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                // Convert user to corresponding DTO
                var appUserDTO = new AppUserDTO()
                {
                    Id = appUser.Id,
                    Email = appUser.Email,
                    Password = appUser.Password,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    IsActive = appUser.IsActive
                };

                var loginResponse = new AuthResponse()
                {
                    AppUser = appUserDTO,
                    Token = tokenString
                };

                return loginResponse;
            }
        }

        public AppUserDTO Create(AppUser appUser)
        {
            //TODO: Implement password hashing for enterprise level security.
            // Decode password from front-end.
            byte[] data = Convert.FromBase64String(appUser.Password);
            string decodedString = Encoding.UTF8.GetString(data);

            // Encode password using back-end encoding ready for the database.
            PasswordHash hash = new PasswordHash(decodedString);
            byte[] hashBytes = hash.ToArray();

            appUser.Password = Convert.ToBase64String(hashBytes);

            var createdAppUser = _respository.Create(appUser);

            //INotificationEmail noficationEmail = new NotifyReg(new NotifyRegModel()
            //{
            //    recipientAddress = appUser.Email,
            //});
            //noficationEmail.EmailNotify();

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

        public bool Reset(string emailAddress)
        {
            var appUser = _respository.GetAppUserByEmail(emailAddress);
            if (appUser == null)
            {
                return false;
            }

            PasswordGenerator passGen = new PasswordGenerator();
            var generatedPassword = passGen.RandomPassword(8);

            PasswordHash hash = new PasswordHash(generatedPassword);
            byte[] hashBytes = hash.ToArray();

            appUser.Password = Convert.ToBase64String(hashBytes);
            appUser.ForcePasswordReset = true;

            _respository.Update(appUser);

            INotificationEmail noficationEmail = new NotifyPasswordReset(new ResetPasswordModel()
            {
                recipientAddress = appUser.Email,
                Password = generatedPassword,
            });
            noficationEmail.EmailNotify();

            return true;
        }
    }
}
