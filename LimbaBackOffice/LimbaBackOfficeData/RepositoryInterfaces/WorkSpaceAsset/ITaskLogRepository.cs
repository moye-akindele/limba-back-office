using LimbaBackOfficeData.Models.WorkSpaceAsset;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset
{
    public interface ITaskLogRepository
    {
        List<TaskLog> Get();
        TaskLog Get(int taskLogId);
        List<TaskLog> GetUserTaskLogs(int workSpaceUserId);
        TaskLog Create(TaskLog ourTaskLog);
        TaskLog Update(TaskLog ourTaskLog);
        bool Delete(int taskLogId);
    }
}
