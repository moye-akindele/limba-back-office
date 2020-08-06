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

        public bool Create(WorkSpace ourAppUser)
        {
            string queryText = @"INSERT AppUser([Email],[Password],[Username],[UserFirstName],[UserLastName],[IsActive]) 
			values(@Email, @Password, @Username, @UserFirstName, @UserLastName, @IsActive)";

            int rowsAffected = _connection.Execute(queryText, ourAppUser);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }

        public bool Update(WorkSpace workSpace)
        {
            string queryText = @"UPDATE [WorkSpace] 
								SET 
								[Id] = @Id,
								[Name] = @Name,
								[Description] = @Description,
								[CreatorId] = @CreatorId,
								[OwnerId] = @OwnerId
								WHERE Id = " + workSpace.Id;

            int rowsAffected = _connection.Execute(queryText, workSpace);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            string queryText = $"DELETE FROM [WorkSpace] WHERE [Id] = {Id}";

            int rowsAffected = _connection.Execute(queryText, Id);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
