using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Design;
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

        public User FindUserByFacebookd(int FacebookId)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select *" +
                                     " from Users where FacebookId = @FacebookId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FacebookId", FacebookId);

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
                DbCommand cmd = GetCommand("update Users set Email = @Email, DisplayName = @DisplayName, FacebookId = @FacebookId" +
                                     ", FacebookAccessToken = @FacebookAccessToken, TwitterId = @TwitterId " +
                                     ", TwitterToken = @TwitterToken, TwitterSecret = @TwitterSecret, TwitterAccessToken = @TwitterAccessToken" +
                                     ", ReferredBy = @ReferredBy, PasswordSalt = @PasswordSalt" +
                                     ", PasswordHash = @PasswordHash , EmailConfirmed = @EmailConfirmed" + 
                                     ", Birthday = @Birthday, ValidPassword = @ValidPassword" +
                                     " where Id = @Id", conn);
                cmd.CommandType = CommandType.Text;
                
                AddWithNullableValue(cmd, "@Email", user.Email);
                AddWithNullableValue(cmd, "@DisplayName", user.DisplayName);
                AddWithNullableValue(cmd, "@FacebookId", user.FacebookId);
                AddWithNullableValue(cmd, "@FacebookAccessToken", user.FacebookAccessToken);
                AddWithNullableValue(cmd, "@TwitterId", user.TwitterId);
                AddWithNullableValue(cmd, "@TwitterToken", user.TwitterToken);
                AddWithNullableValue(cmd, "@TwitterSecret", user.TwitterSecret);
                AddWithNullableValue(cmd, "@TwitterAccessToken", user.TwitterAccessToken);
                AddWithNullableValue(cmd, "@ReferredBy", user.ReferredBy);
                AddWithNullableValue(cmd, "@PasswordSalt", user.PasswordSalt);
                AddWithNullableValue(cmd, "@PasswordHash", user.PasswordHash);
                AddWithNullableValue(cmd, "@EmailConfirmed", user.EmailConfirmed);
                AddWithNullableValue(cmd, "@Birthday", user.Birthday);
                AddWithNullableValue(cmd, "@ValidPassword", user.ValidPassword);
                AddWithNullableValue(cmd, "@Id", user.Id);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public int CreateUser(string email, string password, byte[] hash, byte[] salt, string referralCode)
        {
            // http://stackoverflow.com/a/10402129/11236

            int UsersID = 0;
            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt, ValidPassword, ReferralCode) values (@Email, @Hash, @Salt, @ValidPassword, @ReferralCode); ",
                        conn);
                var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Hash", hash);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@ReferralCode", referralCode);
                cmd.Parameters.AddWithValue("@ValidPassword", false);

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

            int UsersID;
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