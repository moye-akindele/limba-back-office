using Dapper;
using LimbaBackOfficeData.Enums;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Models.ReferencialAsset;
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
        public List<WorkSpaceModel> Get()
        {
            string queryText = @"SELECT * FROM WorkSpace";
            return _connection.Query<WorkSpaceModel>(queryText).ToList();
        }

        public WorkSpaceModel Get(int workSpaceId)
        {
            string queryText = $"SELECT * FROM WorkSpaceWHERE Id = {workSpaceId}";
            WorkSpaceModel workSpace = _connection.Query<WorkSpaceModel>(queryText).FirstOrDefault();
            return workSpace;
        }

        public List<WorkSpaceModel> GetUserWorkSpaces(int appUserId)
        {
            string queryText = $"select* from WorkSpace where Id in " +
                $"(select WorkSpaceId from WorkSpaceUser where AppUserId = {appUserId})";

            List<WorkSpaceModel> workSpace = _connection.Query<WorkSpaceModel>(queryText).ToList();
            return workSpace;
        }

        public List<WorkSpaceUser> GetWorkSpaceUsers(int workSpaceId)
        {
            string queryText = $"select wsu.WorkSpaceId, wsu.AccessLevel, wsu.Position, au.*, dep.* from WorkSpaceUser wsu " +
                $"inner join AppUser au ON au.Id = wsu.AppUserId " +
                $"inner join Ref_Department dep ON dep.Id = wsu.DepartmentId " +
                $"where wsu.WorkSpaceId = {workSpaceId}";

            List<WorkSpaceUser> workSpaceUsers = _connection.Query<WorkSpaceUser, AppUser, Department, WorkSpaceUser >(queryText, (workSpaceUser, appUser, department) =>
            {
                workSpaceUser.MappedUser = appUser;
                workSpaceUser.Department = department;
                return workSpaceUser;
            }, splitOn: "Id, Id").ToList();

            return workSpaceUsers;
        }

        public bool Create(WorkSpaceModel ourWorkSpace)
        {
            string queryText = @"INSERT WorkSpace([Name],[Description],[CreatorId],[IsActive]) 
            OUTPUT INSERTED.Id
			values(@Name, @Description, @CreatorId, @IsActive)";

            int insertedRowId = _connection.QuerySingle<int>(queryText, ourWorkSpace);

            if (insertedRowId > 0)
            {
                WorkSpaceUserMap spaceMap = new WorkSpaceUserMap();
                spaceMap.WorkSpaceId = insertedRowId;
                spaceMap.AppUserId = ourWorkSpace.CreatorId;
                // The work space creator is always an admin.
                spaceMap.AccessLevel = AccessLevel.Admin;
                spaceMap.DepartmentId = 0; // 0 represents the Pseudo DepartmentId.

                CreateUserWorkGroupMap(spaceMap);
                return true;
            }

            return false;
        }

        // Map the space creator to the newly created work space.
        public bool CreateUserWorkGroupMap(WorkSpaceUserMap ourWorkSpaceUserMap)
        {
            string queryText = @"INSERT WorkSpaceUser([WorkSpaceId],[AppUserId],[AccessLevel],[DepartmentId])
			values(@WorkSpaceId, @AppUserId, @AccessLevel, @DepartmentId)";

            int rowsAffected = _connection.Execute(queryText, ourWorkSpaceUserMap);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }

        public bool Update(WorkSpaceModel workSpace)
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
