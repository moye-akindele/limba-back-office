using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimbaBackOffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public AppUserDTO Post(AuthRequest request)
        {
            var retrievedUser = _service.GetAppUserByEmail(request.Email, request.Password);

            if (retrievedUser == null)
            {
                throw new ArgumentException($"Failed to find specified user credentials.");
            }

            return retrievedUser;
        }

        // POST api/<AuthController>
        [HttpPost("register")]
        public AppUserDTO Post(AppUser appUser)
        {
            var createdEntry = _service.Create(appUser);

            if (createdEntry == null)
            {
                throw new ArgumentException($"Failed to create new user.");
            }

            return createdEntry;
        }
    }
}
