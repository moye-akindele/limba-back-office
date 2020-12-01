using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimbaBackOffice.ServiceInterfaces.WorkSpaceAsset;
using LimbaBackOfficeData.DTOs.WorkSpaceAsset;
using LimbaBackOfficeData.Models.WorkSpaceAsset;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LimbaBackOffice.Controllers.WorkSpaceAsset
{
    [Route("[controller]")]
    [ApiController]
    public class TaskLogsController : ControllerBase
    {
        private readonly ITaskLogService _service;

        public TaskLogsController(ITaskLogService service)
        {
            _service = service;
        }

        // GET: api/<TaskLogsController>
        [HttpGet]
        public List<TaskLogDTO> Get()
        {
            return _service.Get();
        }

        // GET api/<TaskLogsController>/5
        [HttpGet("{id}")]
        public TaskLogDTO Get(int id)
        {
            TaskLogDTO item = _service.Get(id);
            if (item == null)
            {
                throw new ArgumentException($"No task log found with Id {id}.");
            }
            return item;
        }

        // GET api/<TaskLogsController>/5
        [HttpGet("user/{workSpaceUserId}")]
        public List<TaskLogDTO> GetUserTaskLogs(int workSpaceUserId)
        {
            var item = _service.GetUserTaskLogs(workSpaceUserId);
            if (item == null)
            {
                throw new ArgumentException($"No task log found for specified user.");
            }
            return item;
        }

        // POST api/<TaskLogsController>
        [HttpPost]
        public TaskLogDTO Post(TaskLog taskLog)
        {
            var createdEntry = _service.Create(taskLog);

            if (createdEntry == null)
            {
                throw new ArgumentException($"Failed to create new task log.");
            }

            return createdEntry;
        }

        // PUT api/<TaskLogsController>/5
        [HttpPut]
        public bool Put(TaskLog taskLog)
        {
            var updatedEntry = _service.Update(taskLog);

            if (updatedEntry == null)
            {
                throw new ArgumentException($"Failed to update task log.");
            }

            return true;
        }

        // DELETE api/<TaskLogsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
