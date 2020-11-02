using Dapper;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LimbaBackOfficeData.Repositories
{
    public class WorkSpaceRespository : IWorkSpaceRespository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public WorkSpaceRespository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["Data:DefaultConnection:ConnectionString"]);
        }
        public List<WorkSpace> Get()
        {
            string queryText = @"SELECT * FROM WorkSpace";
            return _connection.Query<WorkSpace>(queryText).ToList();
        }

        public WorkSpace Get(int workSpaceId)
        {
            string queryText = $"SELECT * FROM WorkSpaceWHERE Id = {workSpaceId}";
            WorkSpace workSpace = _connection.Query<WorkSpace>(queryText).FirstOrDefault();
            return workSpace;
        }

        public List<WorkSpace> GetUserWorkSpaces(int appUserId)
        {
            string queryText = $"select* from WorkSpace where Id in " +
                $"(select WorkSpaceId from WorkSpaceUser where AppUserId = {appUserId})";

            List<WorkSpace> workSpace = _connection.Query<WorkSpace>(queryText).ToList();
            return workSpace;
        }

        public bool Create(WorkSpace ourWorkSpace)
        {
            string queryText = @"INSERT WorkSpace([Name],[Description],[CreatorId],[OwnerId],[IsActive]) 
            OUTPUT INSERTED.Id
			values(@Name, @Description, @CreatorId, @OwnerId, @IsActive)";

            int insertedRowId = _connection.QuerySingle<int>(queryText, ourWorkSpace);

            if (insertedRowId > 0)
            {
                WorkSpaceUserMap spaceMap = new WorkSpaceUserMap();
                spaceMap.WorkSpaceId = insertedRowId;
                spaceMap.AppUserId = ourWorkSpace.CreatorId;

                MapUserToWorkGroup(spaceMap);
                return true; 
            }

            return false;
        }

        public bool MapUserToWorkGroup(WorkSpaceUserMap ourWorkSpaceUserMap)
        {
            string queryText = @"INSERT WorkSpaceUser([WorkSpaceId],[AppUserId]) 
			values(@WorkSpaceId, @AppUserId)";

            int rowsAffected = _connection.Execute(queryText, ourWorkSpaceUserMap);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }

        public bool Update(WorkSpace workSpace)
        {
            string queryText = @"UPDATE [WorkSpace]
								SET
								[Name] = @Name,
								[Description] = @Description,
								[CreatorId] = @CreatorId,
								[OwnerId] = @OwnerId,
                                [IsActive] = @IsActive
								WHERE Id = " + workSpace.Id;

            int rowsAffected = _connection.Execute(queryText, workSpace);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            // First delete all user mappings related to the work space.
            DeleteWorkGroupUserMapping(id);

            // Delete the actual work space itself.
            string queryText = $"DELETE FROM [WorkSpace] WHERE [Id] = {id}";

            int rowsAffected = _connection.Execute(queryText, id);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteWorkGroupUserMapping(int ourWorkSpaceId)
        {
            string queryText = $"DELETE FROM [WorkSpaceUser] WHERE [WorkSpaceId] = {ourWorkSpaceId}";

            int rowsAffected = _connection.Execute(queryText, ourWorkSpaceId);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }
    }
}
