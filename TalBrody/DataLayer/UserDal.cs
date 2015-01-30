using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlServerCe;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;
using log4net;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
	public class UserDal : BaseDal
	{
		public User FindUserByEmail(string email)
		{
			User user = null;
			using (var conn = GetPortalConnection())
			{
				var cmd = GetCommand("select Id, Email, PasswordHash, PasswordSalt from Users where Email = @Email", conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@Email", email);

				conn.Open();
				var reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					user = Populators.Populate_User(reader);
				}
				return user;
			}
		}

		public int CreateUser(string email, string password)
		{
			// http://stackoverflow.com/a/10402129/11236
			var salt = CreateSalt();
			var hashed = Hash(password, salt);
			int UsersID = 0;
			using (var conn = GetPortalConnection())
			{
				var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt) values (@Email, @Hash, @Salt) 	select @UsersID =  IDENT_CURRENT('Users')", conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@Email", email);
				cmd.Parameters.AddWithValue("@Hash", hashed);
				cmd.Parameters.AddWithValue("@Salt", salt);
				cmd.Parameters.Add("@UsersID", SqlDbType.Int).Direction = ParameterDirection.Output;
				conn.Open();
				var result = cmd.ExecuteNonQuery();
				if (result != 1)
				{
					throw new Exception("Expected result 1, got " + result);
				}
				UsersID = (int)cmd.Parameters["@UsersID"].Value;
			}
			return UsersID;
		}

		public bool CheckUser(string email, string password)
		{
			var user = FindUserByEmail(email);
			if (user == null)
			{
				//log.Debug("Didn't find user with email = " + email);
				return false;
			}
			var hash = Hash(password, user.PasswordSalt);
			return hash.SequenceEqual(user.PasswordHash);
		}

		private static byte[] CreateSalt()
		{
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

			return salt;
		}

		public byte[] Hash(string password, byte[] salt)
		{
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			return pbkdf2.GetBytes(20);
		}
	}
}