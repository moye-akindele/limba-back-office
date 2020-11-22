using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimbaBackOffice.ServiceInterfaces.ReferencialAsset;
using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Models.ReferencialAsset;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LimbaBackOffice.Controllers.ReferencialAsset
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public List<DepartmentDTO> Get()
        {
            return _service.Get();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public DepartmentDTO Get(int id)
        {
            DepartmentDTO item = _service.Get(id);
            if (item == null)
            {
                throw new ArgumentException($"No Department found with Id {id}.");
            }
            return item;
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post(Department department)
        {
            var createdEntry = _service.Create(department);

            if (createdEntry == false)
            {
                throw new ArgumentException($"Failed to create new department.");
            }
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(Department department)
        {
            _service.Update(department);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
