using LimbaBackOfficeData.DTOs.WorkSpaceAsset;
using LimbaBackOfficeData.Models.WorkSpaceAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces.WorkSpaceAsset
{
    public interface ITaskLogService
    {
        List<TaskLogDTO> Get();
        TaskLogDTO Get(int taskLogId);
        List<TaskLogDTO> GetUserTaskLogs(int workSpaceUserId);
        TaskLogDTO Create(TaskLog ourTaskLog);
        TaskLogDTO Update(TaskLog ourTaskLog);
        bool Delete(int taskLogId);
    }
}
