using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
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
        public List<WorkSpaceDTO> Get()
        {
            return _service.Get();
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
        public void Post(WorkSpace workSpace)
        {
            var createdEntry = _service.Create(workSpace);

            if (createdEntry == false)
            {
                throw new ArgumentException($"Failed to create new work space.");
            }
        }

        // PUT api/<WorkSpacesController>/5
        [HttpPut("{id}")]
        public void Put(WorkSpace workSpace)
        {
            _service.Update(workSpace);
        }

        // DELETE api/<WorkSpacesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
