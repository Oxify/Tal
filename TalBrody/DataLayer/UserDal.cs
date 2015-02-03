using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using TalBrody.Entity;
using TalBrody.Common;

namespace TalBrody.DataLayer
{
    public class UserDal : BaseDal
    {
        public User FindUserByEmail(string email)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select Id, DisplayName, Email, FacebookId, TwitterId, ReferencedBy, PasswordSalt, PasswordHash" +
                                     " from Users where Email = @Email", conn);
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

        public int CreateUser(string email, string password, byte[] hash, byte[] salt)
        {
            // http://stackoverflow.com/a/10402129/11236
           
            int UsersID = 0;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt) values (@Email, @Hash, @Salt) 	select @UsersID =  IDENT_CURRENT('Users')", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Hash", hash);
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
    }
}