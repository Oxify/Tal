using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
                var cmd = GetCommand("select *" +
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

        public User FindUserByid(int id)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select *" +
                                     " from Users where Id = @id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = Populators.Populate_User(reader);
                }
                return user;
            }

        }

        public User FindUserByTwitterid(int Twitterid)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select *" +
                                     " from Users where TwitterId = @Twitterid", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Twitterid", Twitterid);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = Populators.Populate_User(reader);
                }
                return user;
            }

        }

        public User FindUserByFacebookd(int Facebookd)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select *" +
                                     " from Users where FacebookId = @Facebookd", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Facebookd", Facebookd);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = Populators.Populate_User(reader);
                }
                return user;
            }

        }

        public void UpdateUser(User user)
        {
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("update Users set Email = @Email, DisplayName = @DisplayName, FacebookId = @FacebookId" +
                                     ", FacebookAccessToken = @FacebookAccessToken, TwitterId = @TwitterId " +
                                     ", TwitterToken = @TwitterToken, TwitterSecret = @TwitterSecret, TwitterAccessToken = @TwitterAccessToken" +
                                     ", ReferredBy = @ReferredBy, PasswordSalt = @PasswordSalt" +
                                     ", PasswordHash = @PasswordHash , EmailConfirmed = @EmailConfirmed" + 
                                     ", Birthday = @Birthday, ValidPassword = @ValidPassword" +
                                     " where Id = @Id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                cmd.Parameters.AddWithValue("@FacebookId", user.FacebookId);
                cmd.Parameters.AddWithValue("@FacebookAccessToken", user.FacebookAccessToken);
                cmd.Parameters.AddWithValue("@TwitterId", user.TwitterId);
                cmd.Parameters.AddWithValue("@TwitterToken", user.TwitterToken);
                cmd.Parameters.AddWithValue("@TwitterSecret", user.TwitterSecret);
                cmd.Parameters.AddWithValue("@TwitterAccessToken", user.TwitterAccessToken);
                cmd.Parameters.AddWithValue("@ReferredBy", user.ReferredBy);
                cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@EmailConfirmed", user.EmailConfirmed);
                cmd.Parameters.AddWithValue("@Birthday", user.Birthday);
                cmd.Parameters.AddWithValue("@ValidPassword", user.ValidPassword);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int CreateUser(string email, string password, byte[] hash, byte[] salt)
        {
            // http://stackoverflow.com/a/10402129/11236

            int UsersID = 0;
            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt, PasswordValid) values (@Email, @Hash, @Salt, False); ",
                        conn);
                var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Hash", hash);
                cmd.Parameters.AddWithValue("@Salt", salt);
               
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID",conn);
                cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                UsersID = Convert.ToInt32(o);
               
                tr.Commit();
            }
            return UsersID;
        }

        public int CreateUser(User user)
        {
            // http://stackoverflow.com/a/10402129/11236

            int UsersID = 0;
            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("insert into Users (Email, ValidPassword) values (@Email, False); ",
                        conn);
                //      var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", user.Email);

                //         cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID", conn);
                //          cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                UsersID = Convert.ToInt32(o);
            }
            return UsersID;
        }
    }
}