using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
// using System.Web.Http;
using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Repositories;
using LimbaBackOfficeData.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
                //var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                //    ReasonPhrase = "Product ID Not Found"
                //};
                //throw new HttpResponseException(resp);
            }

            return item;
        }

        // POST api/<AppUsersController>
        [HttpPost]
        public void Post(AppUser appUser)
        {
            _service.Create(appUser);
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
    }
}
