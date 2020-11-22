using Dapper;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LimbaBackOfficeData.Repositories
{
    public class AppUserRespository : IAppUserRespository
    {
		private readonly IConfiguration _configuration;
		private readonly IDbConnection _connection;
		public AppUserRespository(IConfiguration configuration)
        {
			_configuration = configuration;
			_connection = new SqlConnection(_configuration["Data:DefaultConnection:ConnectionString"]);
		}

		public List<AppUser> Get()
		{
			string queryText = @"SELECT * FROM AppUser";
			return  _connection.Query<AppUser>(queryText).ToList();
		}

		public AppUser Get(int appUserId)
		{
			string queryText = "SELECT * FROM AppUser WHERE Id = " + appUserId;
			AppUser seletedUser = _connection.Query<AppUser>(queryText).FirstOrDefault();
			return seletedUser;
		}

		public AppUser Create(AppUser ourAppUser)
		{
			// Do not create the user if the email is already in use.
			if (GetAppUserByEmail(ourAppUser.Email) != null)
			{ 
				return null;
			}

			string queryText = @"INSERT AppUser([Email],[Password],[FirstName],[LastName],[IsActive],[ForcePasswordReset]) 
			OUTPUT INSERTED.* 
			values(@Email, @Password, @FirstName, @LastName, @IsActive, @ForcePasswordReset)";

			var createdAppUser = _connection.QuerySingle<AppUser>(queryText, ourAppUser);

			if (createdAppUser != null)
            { return createdAppUser; }

            return null;
        }

		public AppUser Update(AppUser ourAppUser)
		{
			string queryText = @"UPDATE [AppUser] 
								SET 
								[Email] = @Email,
								[Password] = @Password,
								[FirstName] = @FirstName,
								[LastName] = @LastName,
								[IsActive] = @IsActive,
								[ForcePasswordReset] = @ForcePasswordReset
								WHERE Id = " + ourAppUser.Id;

			var rowsAffected = _connection.Execute(queryText, ourAppUser);

			if (rowsAffected > 0)
			{
				return ourAppUser;
			}
			return null;
		}

		public bool Delete(int Id)
		{
			string queryText = @"DELETE FROM [AppUser] WHERE [Id] = " + Id;

			int rowsAffected = _connection.Execute(queryText, Id);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}

		public AppUser GetAppUserByEmail(string appUserEmail)
		{
			string queryText = $"SELECT * FROM AppUser WHERE Email = '{appUserEmail}'";
			AppUser seletedUser = _connection.Query<AppUser>(queryText).FirstOrDefault();
			return seletedUser;
		}
	}
}
