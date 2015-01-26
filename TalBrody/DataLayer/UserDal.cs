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
using Oxify.Entity;
using log4net;

namespace Oxify.DataLayer
{
	public class UserDal : BaseDal
    {
	    public User FindUserByEmail(string email)
	    {
            using (var conn = GetPortalConnection())
            {
				var cmd = GetCommand("select Id, Email, PasswordHash, PasswordSalt from Users where Email = @Email", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }

                var user = new User
                {
                    Id = (int) reader[0], 
                    Email = (string) reader[1],
                    PasswordHash = (byte[]) reader[2],
                    PasswordSalt = (byte[]) reader[3]
                };
                return user;
            }
	    }

	    public void CreateUser(string email, string password)
	    {
            // http://stackoverflow.com/a/10402129/11236
	        var salt = CreateSalt();
	        var hashed = Hash(password, salt);

	        using (var conn = GetPortalConnection())
	        {
				var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt) values (@Email, @Hash, @Salt)", conn);
                cmd.CommandType = CommandType.Text;
	            cmd.Parameters.AddWithValue("@Email", email);
	            cmd.Parameters.AddWithValue("@Hash", hashed);
	            cmd.Parameters.AddWithValue("@Salt", salt);
                conn.Open();
	            var result = cmd.ExecuteNonQuery();
	            if (result != 1)
	            {
	                throw new Exception("Expected result 1, got " + result);
	            }
	        }
	    }

	    public bool CheckUser(string email, string password)
	    {
	        var user = FindUserByEmail(email);
	        if (user == null)
	        {
                log.Debug("Didn't find user with email = " + email);
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