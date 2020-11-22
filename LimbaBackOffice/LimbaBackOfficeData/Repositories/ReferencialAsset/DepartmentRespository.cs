using Dapper;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.Models.ReferencialAsset;
using LimbaBackOfficeData.RepositoryInterfaces;
using LimbaBackOfficeData.RepositoryInterfaces.ReferencialAsset;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LimbaBackOfficeData.Repositories
{
    public class DepartmentRespository : IDepartmentRespository
	{
		private readonly IConfiguration _configuration;
		private readonly IDbConnection _connection;
		private readonly string _baseTableName = "Ref_Department";
		public DepartmentRespository(IConfiguration configuration)
        {
			_configuration = configuration;
			_connection = new SqlConnection(_configuration["Data:DefaultConnection:ConnectionString"]);
		}

		public List<Department> Get()
		{
			string queryText = $"SELECT * FROM {_baseTableName}";
			return  _connection.Query<Department>(queryText).ToList();
		}

		public Department Get(int departmentId)
		{
			string queryText = $"SELECT * FROM {_baseTableName} WHERE Id = {departmentId}";
			Department seletedDepartment = _connection.Query<Department>(queryText).FirstOrDefault();
			return seletedDepartment;
		}

		public bool Create(Department ourDepartment)
		{
			string queryText = $"INSERT {_baseTableName}([Name],[Description],[InternalType]) " +
				$"values(@Name, @Description, @InternalType)";

			int rowsAffected = _connection.Execute(queryText, ourDepartment);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }

		public bool Update(Department ourDepartment)
		{
			string queryText = $"UPDATE {_baseTableName}" +

								@"SET 
								[Name] = @Name,
								[Description] = @Description,
								[InternalType] = @InternalType" +

								$"WHERE Id = {ourDepartment.Id}";

			int rowsAffected = _connection.Execute(queryText, ourDepartment);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}

		public bool Delete(int Id)
		{
			string queryText = $"DELETE FROM {_baseTableName} WHERE [Id] = {Id}";

			int rowsAffected = _connection.Execute(queryText, Id);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}
	}
}
