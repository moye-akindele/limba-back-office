using System;
using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LimbaBackOffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public IConfiguration Configuration { get; }

        public AuthController(IAuthService service, IConfiguration configuration)
        {
            _service = service;
            Configuration = configuration;
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public IActionResult Post(AuthRequest request)
        {
            if (request == null)
            {
                // return BadRequest("Invalid client request");
            }

            var retrievedResponse = _service.GetAppUserByEmail(request.Email, request.Password);

            if (retrievedResponse == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(retrievedResponse);
            }
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

        // POST api/<AuthController>
        [HttpPost("reset/{emailAddress}")]
        public bool Post(string emailAddress)
        {
            var isResetSuccessful = _service.Reset(emailAddress);

            return isResetSuccessful;
        }
    }
}
