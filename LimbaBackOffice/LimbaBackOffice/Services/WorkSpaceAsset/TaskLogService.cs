using LimbaBackOffice.ServiceInterfaces.WorkSpaceAsset;
using LimbaBackOfficeData.DTOs.WorkSpaceAsset;
using LimbaBackOfficeData.Models.WorkSpaceAsset;
using LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services.WorkSpaceAsset
{
    public class TaskLogService : ITaskLogService
    {
        private readonly ITaskLogRepository _respository;

        public TaskLogService(ITaskLogRepository respository)
        {
            _respository = respository;
        }

        public List<TaskLogDTO> Get()
        {
            var taskLogs = _respository.Get();

            var taskLogList = from taskLog in taskLogs
                              select new TaskLogDTO()
                              {
                                  Id = taskLog.Id,
                                  WorkSpaceUserId = taskLog.WorkSpaceUserId,
                                  Name = taskLog.Name,
                                  Category = taskLog.Category,
                                  StartDateTime = taskLog.StartDateTime,
                                  EndDateTime = taskLog.EndDateTime,
                                  Note = taskLog.Note,
                              };

            return taskLogList.ToList();
        }

        public TaskLogDTO Get(int taskLogId)
        {
            // check if record exists
            var taskLog = _respository.Get(taskLogId);
            if (taskLog == null)
            {
                return null;
            }

            // Convert to DTO
            var taskLogDTO = new TaskLogDTO()
            {
                Id = taskLog.Id,
                WorkSpaceUserId = taskLog.WorkSpaceUserId,
                Name = taskLog.Name,
                Category = taskLog.Category,
                StartDateTime = taskLog.StartDateTime,
                EndDateTime = taskLog.EndDateTime,
                Note = taskLog.Note,
            };

            return taskLogDTO;
        }

        public List<TaskLogDTO> GetUserTaskLogs(UserTaskLogsRequest taskRequest)
        {
            var taskLogs = _respository.GetUserTaskLogs(taskRequest);

            var taskLogList = from taskLog in taskLogs
                              select new TaskLogDTO()
                              {
                                  Id = taskLog.Id,
                                  WorkSpaceUserId = taskLog.WorkSpaceUserId,
                                  Name = taskLog.Name,
                                  Category = taskLog.Category,
                                  StartDateTime = taskLog.StartDateTime,
                                  EndDateTime = taskLog.EndDateTime,
                                  Note = taskLog.Note,
                              };

            return taskLogList.ToList();
        }

        public TaskLogDTO Create(TaskLog ourTaskLog)
        {
            var createdTaskLog = _respository.Create(ourTaskLog);

            var taskLogDTO = new TaskLogDTO()
            {
                Id = createdTaskLog.Id,
                WorkSpaceUserId = createdTaskLog.WorkSpaceUserId,
                Name = createdTaskLog.Name,
                Category = createdTaskLog.Category,
                StartDateTime = createdTaskLog.StartDateTime,
                EndDateTime = createdTaskLog.EndDateTime,
                Note = createdTaskLog.Note,
            };

            return taskLogDTO;
        }

        public TaskLogDTO Update(TaskLog ourTaskLog)
        {
            var updatedTaskLog = _respository.Update(ourTaskLog);

            var taskLogDTO = new TaskLogDTO()
            {
                Id = updatedTaskLog.Id,
                WorkSpaceUserId = updatedTaskLog.WorkSpaceUserId,
                Name = updatedTaskLog.Name,
                Category = updatedTaskLog.Category,
                StartDateTime = updatedTaskLog.StartDateTime,
                EndDateTime = updatedTaskLog.EndDateTime,
                Note = updatedTaskLog.Note,
            };

            return taskLogDTO;
        }

        public bool Delete(int taskLogId)
        {
            return _respository.Delete(taskLogId);
        }
    }
}
