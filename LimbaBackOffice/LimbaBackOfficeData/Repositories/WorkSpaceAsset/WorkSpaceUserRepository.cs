using Dapper;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Models.ReferencialAsset;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset
{
    public class WorkSpaceUserRepository : IWorkSpaceUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public WorkSpaceUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration["Data:DefaultConnection:ConnectionString"]);
        }

        public List<WorkSpaceUser> Get(int workSpaceId)
        {
            string queryText = $"select wsu.Id, wsu.WorkSpaceId, wsu.AccessLevel, wsu.Position, au.*, dep.* from WorkSpaceUser wsu " +
                $"inner join AppUser au ON au.Id = wsu.AppUserId " +
                $"inner join Ref_Department dep ON dep.Id = wsu.DepartmentId " +
                $"where wsu.WorkSpaceId = {workSpaceId}";

            List<WorkSpaceUser> workSpaceUsers = _connection.Query<WorkSpaceUser, AppUser, Department, WorkSpaceUser>(queryText, (workSpaceUser, appUser, department) =>
            {
                workSpaceUser.MappedUser = appUser;
                workSpaceUser.Department = department;
                return workSpaceUser;
            }, splitOn: "Id, Id").ToList();

            return workSpaceUsers;
        }

        public WorkSpaceUser Get(int workSpaceId, int userId)
        {
            throw new NotImplementedException();
        }

        public WorkSpaceUserMap Create(WorkSpaceUser ourWorkSpaceUser)
        {
            string queryText = @"INSERT WorkSpaceUser([WorkSpaceId],[AppUserId],[AccessLevel],[DepartmentId],[Position])
            OUTPUT INSERTED.* 
			values(@WorkSpaceId, @AppUserId, @AccessLevel, @DepartmentId, @Position)";

            var userMapping = new WorkSpaceUserMap() 
            { 
                Id = 0,
                WorkSpaceId = ourWorkSpaceUser.WorkSpaceId,
                AppUserId = ourWorkSpaceUser.MappedUser.Id,
                Position = ourWorkSpaceUser.Position,
                DepartmentId = ourWorkSpaceUser.Department.Id,
                AccessLevel = ourWorkSpaceUser.AccessLevel,
            };

            var createdMapping = _connection.QuerySingle<WorkSpaceUserMap>(queryText, userMapping);

            if (createdMapping != null)
            { return createdMapping; }

            return null;
        }

        public WorkSpaceUser Update(WorkSpaceUser ourWorkSpaceUser)
        {
            string queryText = @"UPDATE [WorkSpaceUser] 
								SET 
								[WorkSpaceId] = @WorkSpaceId,
								[AppUserId] = @AppUserId,
								[AccessLevel] = @AccessLevel,
								[DepartmentId] = @DepartmentId,
								[Position] = @Position
								WHERE Id = " + ourWorkSpaceUser.Id;

            var userMapping = new WorkSpaceUserMap()
            {
                Id = ourWorkSpaceUser.Id,
                WorkSpaceId = ourWorkSpaceUser.WorkSpaceId,
                AppUserId = ourWorkSpaceUser.MappedUser.Id,
                Position = ourWorkSpaceUser.Position,
                DepartmentId = ourWorkSpaceUser.Department.Id,
                AccessLevel = ourWorkSpaceUser.AccessLevel,
            };

            var rowsAffected = _connection.Execute(queryText, userMapping);

            if (rowsAffected > 0)
            { return ourWorkSpaceUser; }

            return null;
        }

        public bool Delete(int workSpaceUserId)
        {
            string queryText = @"DELETE FROM [WorkSpaceUser] WHERE [Id] = " + workSpaceUserId;

			int rowsAffected = _connection.Execute(queryText, workSpaceUserId);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
        }
    }
}
