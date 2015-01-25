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
using System.Web.UI.HtmlControls;
using fblogin.Entity;
using log4net;

namespace fblogin.DataLayer
{
	public class UserDal : BaseDal
    {
	    public User FindUserByEmail(string email)
	    {
            using (var conn = GetPortalConnection())
            {
				var cmd = GetCommand("select Id, Email from Users where Email = @Email", conn);
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
                    Email = (string) reader[1]
                };
                return user;
            }
	    }

	    public void CreateUser(string email)
	    {
	        using (var conn = GetPortalConnection())
	        {
				var cmd = GetCommand("insert into Users (Email) values (@Email)", conn);
                cmd.CommandType = CommandType.Text;
	            cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
	            var result = cmd.ExecuteNonQuery();
	            if (result != 1)
	            {
	                throw new Exception("Expected result 1, got " + result);
	            }
	        }
	    }
    }
}