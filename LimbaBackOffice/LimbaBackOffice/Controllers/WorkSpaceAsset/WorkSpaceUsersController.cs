using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOffice.ServiceInterfaces.WorkSpace;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LimbaBackOffice.Controllers.WorkSpace
{
    [Route("[controller]")]
    [ApiController]
    public class WorkSpaceUsersController : ControllerBase
    {
        private readonly IWorkSpaceUserService _service;

        public WorkSpaceUsersController(IWorkSpaceUserService service)
        {
            _service = service;
        }

        // GET: api/<AppUsersController>
        [HttpGet("{workSpaceId}")]
        public List<WorkSpaceUserDTO> Get(int workSpaceId)
        {
            return _service.Get(workSpaceId);
        }

        // GET api/<AppUsersController>/5
        //[HttpGet("{id}")]
        //public WorkSpaceUserDTO Get(int workSpaceId, int userId)
        //{
        //    WorkSpaceUserDTO item = _service.Get(workSpaceId, userId);
        //    if (item == null)
        //    {
        //        throw new ArgumentException($"Specified user not found.");
        //    }
        //    return item;
        //}

        // POST api/<WorkSpaceUsersController>
        [HttpPost]
        public bool Post(WorkSpaceUser workSpaceUser)
        {
            var createdEntry = _service.Create(workSpaceUser);

            if (createdEntry == false)
            {
                throw new ArgumentException($"Failed to create new user.");
            }

            return createdEntry;
        }

        [HttpPut]
        public bool Put(WorkSpaceUser workSpaceUser)
        {
            var updatedEntry = _service.Update(workSpaceUser);

            if (updatedEntry == false)
            {
                throw new ArgumentException($"Failed to update space user.");
            }

            return updatedEntry;

        }

        // DELETE api/<AppUsersController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
