using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LimbaBackOffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkSpacesController : ControllerBase
    {
        private readonly IWorkSpaceService _service;

        public WorkSpacesController(IWorkSpaceService service)
        {
            _service = service;
        }

        // GET: api/<WorkSpacesController>
        [HttpGet]
        [Authorize]
        public List<WorkSpaceDTO> Get()
        {
            return _service.Get();
        }

        // GET: api/<AppUsersController>
        [HttpGet("userWorkSpace/{appUserId}")]
        public List<WorkSpaceDTO> GetUserWorkSpaces(int appUserId)
        {
            var item = _service.GetUserWorkSpaces(appUserId);
            if (item == null)
            {
                throw new ArgumentException($"No work space found for selected user.");
            }
            return item;
        }

        // GET: api/<AppUsersController>
        [HttpGet("{workSpaceId}/users")]
        public List<WorkSpaceUserDTO> GetWorkSpaceUsers(int workSpaceId)
        {
            var item = _service.GetWorkSpaceUsers(workSpaceId);
            if (item == null)
            {
                throw new ArgumentException($"No users found for selected work space.");
            }
            return item;
        }

        // GET api/<WorkSpacesController>/5
        [HttpGet("{id}")]
        public WorkSpaceDTO Get(int id)
        {
            WorkSpaceDTO item = _service.Get(id);
            if (item == null)
            {
                throw new ArgumentException($"No Work Space found with Id {id}.");
            }
            return item;
        }

        // POST api/<WorkSpacesController>
        [HttpPost]
        public bool Post(WorkSpaceModel workSpace)
        {
            var createdEntry = _service.Create(workSpace);

            if (createdEntry == false)
            {
                throw new ArgumentException($"Failed to create new work space.");
            }

            return createdEntry;
        }

        // PUT api/<WorkSpacesController>/5
        [HttpPut]
        public bool Put(WorkSpaceModel workSpace)
        {
            var retrievedEntry = _service.Update(workSpace);

            if (retrievedEntry == false)
            {
                throw new ArgumentException($"Failed to update work space.");
            }

            return retrievedEntry;
        }

        // DELETE api/<WorkSpacesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
