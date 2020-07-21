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

		public bool Create(AppUser ourAppUser)
		{
			// Do not create the user if the email is already in use.
			if (GetAppUserByEmail(ourAppUser.Email) != null)
			{ 
				return false;
			}

			string queryText = @"INSERT AppUser([Email],[Password],[Username],[UserFirstName],[UserLastName],[IsActive]) 
			values(@Email, @Password, @Username, @UserFirstName, @UserLastName, @IsActive)";

			int rowsAffected = _connection.Execute(queryText, ourAppUser);

            if (rowsAffected > 0)
            { return true; }

            return false;
        }

		public bool Update(AppUser ourAppUser)
		{
			string queryText = @"UPDATE [AppUser] 
								SET 
								[Email] = @Email,
								[Password] = @Password,
								[Username] = @Username,
								[UserFirstName] = @UserFirstName,
								[UserLastName] = @UserLastName,
								[IsActive] = @IsActive
								WHERE Id = " + ourAppUser.Id;

			int rowsAffected = _connection.Execute(queryText, ourAppUser);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
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
