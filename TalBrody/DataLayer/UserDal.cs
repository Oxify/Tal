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
                var cmd = GetCommand("select Id, DisplayName, Email, FacebookId, TwitterId, ReferencedBy, PasswordSalt, PasswordHash ,EmailComferm" +
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
                var cmd = GetCommand("select Id, DisplayName, Email, FacebookId, TwitterId, ReferencedBy, PasswordSalt, PasswordHash ,EmailComferm" +
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
                var cmd = GetCommand("select Id, DisplayName, Email, FacebookId, TwitterId, ReferencedBy, PasswordSalt, PasswordHash ,EmailComferm" +
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
                var cmd = GetCommand("select Id, DisplayName, Email, FacebookId, TwitterId, ReferencedBy, PasswordSalt, PasswordHash ,EmailComferm" +
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
                                     ", TwitterId = @TwitterId, ReferencedBy = @ReferencedBy, PasswordSalt = @PasswordSalt" +
                                     ", PasswordHash = @PasswordHash , EmailComferm = @EmailComferm where Id = @Id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                cmd.Parameters.AddWithValue("@FacebookId", user.FaceBookId);
                cmd.Parameters.AddWithValue("@TwitterId", user.TwittId);
                cmd.Parameters.AddWithValue("@ReferencedBy", user.ReferanceBy);
                cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@EmailComferm", user.EmailComferm);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.Add("@UsersID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                var cmd = GetCommand("insert into Users (Email, PasswordHash, PasswordSalt) values (@Email, @Hash, @Salt); ",
                        conn);
          //      var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Hash", hash);
                cmd.Parameters.AddWithValue("@Salt", salt);
               
       //         cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID",conn);
      //          cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                UsersID = Convert.ToInt32(o);
            }
            return UsersID;
        }
    }
}