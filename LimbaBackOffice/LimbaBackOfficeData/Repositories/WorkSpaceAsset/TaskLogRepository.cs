using Dapper;
using LimbaBackOfficeData.Models.WorkSpaceAsset;
using LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LimbaBackOfficeData.Repositories.WorkSpaceAsset
{

    public class TaskLogRepository : ITaskLogRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        private const string _dateFormat = "yyyy-MM-dd HH:mm:ss.fff";
        public TaskLogRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["Data:DefaultConnection:ConnectionString"]);
        }

        public List<TaskLog> Get()
        {
            string queryText = @"SELECT * FROM TaskLog";
            return _connection.Query<TaskLog>(queryText).ToList();
        }

        public TaskLog Get(int taskLogId)
        {
            string queryText = "SELECT * FROM TaskLog WHERE Id = " + taskLogId;
            TaskLog seletedTaskLog = _connection.Query<TaskLog>(queryText).FirstOrDefault();
            return seletedTaskLog;
        }

        public List<TaskLog> GetUserTaskLogs(UserTaskLogsRequest taskRequest)
        {
            string queryText = @"SELECT * FROM TaskLog WHERE WorkSpaceUserId = " + taskRequest.WorkSpaceUserId +
                "AND StartDateTime BETWEEN '" + taskRequest.StartDateTime.ToString(_dateFormat) + "' AND '" + taskRequest.EndDateTime.ToString(_dateFormat) + "'";
            return _connection.Query<TaskLog>(queryText).ToList();
        }

        public TaskLog Create(TaskLog ourTaskLog)
        {
            string queryText = @"INSERT TaskLog([WorkSpaceUserId],[Name],[Category],[StartDateTime],[EndDateTime],[Note])
            OUTPUT INSERTED.* 
			values(@WorkSpaceUserId, @Name, @Category, @StartDateTime, @EndDateTime, @Note)";

            var createdTaskLog = _connection.QuerySingle<TaskLog>(queryText, ourTaskLog);

            if (createdTaskLog != null)
            { return createdTaskLog; }

            return null;
        }

        public TaskLog Update(TaskLog ourTaskLog)
        {
            string queryText = @"UPDATE [TaskLog] 
								SET 
                                [WorkSpaceUserId] = @WorkSpaceUserId,
								[Name] = @Name,
								[Category] = @Category,
								[StartDateTime] = @StartDateTime,
                                [EndDateTime] = @EndDateTime,
                                [Note] = @Note
								WHERE Id = " + ourTaskLog.Id;

            var rowsAffected = _connection.Execute(queryText, ourTaskLog);

            if (rowsAffected > 0)
            { return ourTaskLog; }

            return null;
        }

        public bool Delete(int taskLogId)
        {
            string queryText = @"DELETE FROM [TaskLog] WHERE [Id] = " + taskLogId;

            int rowsAffected = _connection.Execute(queryText, taskLogId);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
