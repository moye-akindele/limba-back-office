using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeShared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LimbaBackOffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _service;

        public AppUsersController(IAppUserService service)
        {
            _service = service;
        }

        // GET: api/<AppUsersController>
        [HttpGet]
        public List<AppUserDTO> Get()
        {
            return _service.Get();
        }

        // GET api/<AppUsersController>/5
        [HttpGet("{id}")]
        public AppUserDTO Get(int id)
        {
            AppUserDTO item = _service.Get(id);
            if (item == null)
            {
                throw new ArgumentException($"No appUser found with Id {id}.");
            }
            return item;
        }

        // POST api/<AppUsersController>
        [HttpPost]
        public void Post(AppUser appUser)
        {
            var createdNewUser = _service.Create(appUser);

            if (createdNewUser == false)
            {
                throw new ArgumentException($"Failed to create new user.");
            }
        }

        // PUT api/<AppUsersController>/5
        [HttpPut("{id}")]
        //public void Put(int id, AppUser user)
        public void Put(AppUser appUser)
        {
            _service.Update(appUser);
        }

        // DELETE api/<AppUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        // GET: api/<AppUsersController>
        [HttpGet("email")]
        public AppUserDTO GetAppUserByEmail(string appUserEmail)
        {
            AppUserDTO item = _service.GetAppUserByEmail(appUserEmail);
            if (item == null)
            {
                throw new ArgumentException($"No appUser found with email - {appUserEmail}.");
            }
            return item;
        }
    }
}
