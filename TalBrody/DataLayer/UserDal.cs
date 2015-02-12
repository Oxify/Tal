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
                cmd.Parameters.AddWithNullableValue("@Email", email);

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
                cmd.Parameters.AddWithNullableValue("@id", id);

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
                cmd.Parameters.AddWithNullableValue("@Twitterid", Twitterid);

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
                cmd.Parameters.AddWithNullableValue("@Facebookd", Facebookd);

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
                                     ", FacebookAccessToken = @FacebookAccessToken1, TwitterId = @TwitterId " +
                                     ", TwitterToken = @TwitterToken, TwitterSecret = @TwitterSecret, TwitterAccessToken = @TwitterAccessToken" +
                                     ", ReferredBy = @ReferredBy, PasswordSalt = @PasswordSalt" +
                                     ", PasswordHash = @PasswordHash , EmailConfirmed = @EmailConfirmed" + 
                                     ", Birthday = @Birthday, ValidPassword = @ValidPassword" +
                                     " where Id = @Id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithNullableValue("@Email", user.Email);
                cmd.Parameters.AddWithNullableValue("@DisplayName", user.DisplayName);
                cmd.Parameters.AddWithNullableValue("@FacebookId", user.FacebookId);
                cmd.Parameters.AddWithNullableValue("@FacebookAccessToken1", user.FacebookAccessToken);
                cmd.Parameters.AddWithNullableValue("@TwitterId", user.TwitterId);
                cmd.Parameters.AddWithNullableValue("@TwitterToken", user.TwitterToken);
                cmd.Parameters.AddWithNullableValue("@TwitterSecret", user.TwitterSecret);
                cmd.Parameters.AddWithNullableValue("@TwitterAccessToken", user.TwitterAccessToken);
                cmd.Parameters.AddWithNullableValue("@ReferredBy", user.ReferredBy);
                cmd.Parameters.AddWithNullableValue("@PasswordSalt", user.PasswordSalt);
                cmd.Parameters.AddWithNullableValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithNullableValue("@EmailConfirmed", user.EmailConfirmed);
                cmd.Parameters.AddWithNullableValue("@Birthday", user.Birthday);
                cmd.Parameters.AddWithNullableValue("@ValidPassword", user.ValidPassword);
                cmd.Parameters.AddWithNullableValue("@Id", user.Id);
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
                cmd.Parameters.AddWithNullableValue("@Email", email);
                cmd.Parameters.AddWithNullableValue("@Hash", hash);
                cmd.Parameters.AddWithNullableValue("@Salt", salt);
                cmd.Parameters.AddWithNullableValue("@ReferralCode", referralCode);
                cmd.Parameters.AddWithNullableValue("@ValidPassword", false);

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
                cmd.Parameters.AddWithNullableValue("@Email", user.Email);

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