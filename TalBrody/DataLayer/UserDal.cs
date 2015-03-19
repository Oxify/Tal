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

        public User FindUserByFacebookd(long FaceBookId)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where FacebookId = @FaceBookId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FaceBookId", FaceBookId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = Populators.Populate_User(reader);
                }
                return user;
            }
        }

         public List<User> GetUserByProjectId(int ProjectId)
        {
            List<User> user = new List<User>();
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select Users.[Id],[DisplayName],Users.[Email],[FacebookId],[FacebookAccessToken],[TwitterId]"+
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]"+
            " ,[Birthday],[ValidPassword],[DateCreated],[ReferralCode] "+
            "from Users join Followers on Users.Id = Followers.UserId  where ProjectId = @ProjectId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.Add( Populators.Populate_User(reader));
                }
                return user;
            }

        }

        public User FindUserByEmail(string email)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where Email = @Email", conn);
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
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where Id = @id", conn);
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
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where TwitterId = @Twitterid", conn);
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

        public User FindUserByFacebookId(long FacebookId)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where FacebookId = @FacebookId", conn);
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

         public User FindUserByUserId(int UserId)
        {
            User user = null;
            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select [Id],[DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId]" +
            ",[TwitterToken],[TwitterSecret],[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed]" +
             ",[Birthday],[ValidPassword],[DateCreated],[ReferralCode] from Users where Id = @UserId", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", UserId);

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

                cmd = GetCommand("SELECT @@IDENTITY AS ID", conn);
                cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                UsersID = Convert.ToInt32(o);

                tr.Commit();
            }
            return UsersID;
        }

        public int CreateUser(User user)
        {           

            int UsersID;
           
                using (var conn = PortalConection)
                {
                    conn.Open();
                    var cmd = GetCommand("insert into Users ([DisplayName],[Email],[FacebookId],[FacebookAccessToken],[TwitterId],[TwitterToken]" +
               ",[TwitterSecret] ,[TwitterAccessToken],[ReferredBy],[PasswordSalt],[PasswordHash],[EmailConfirmed],[Birthday],[ValidPassword]" +
               ",[DateCreated],[ReferralCode]) values ( @DisplayName,@Email,@FacebookId,@FacebookAccessToken,@TwitterId,@TwitterToken" +
               ",@TwitterSecret,@TwitterAccessToken,@ReferredBy,@PasswordSalt,@PasswordHash,@EmailConfirmed,@Birthday,@ValidPassword" +
               ",@DateCreated,@ReferralCode); ",
                            conn);
                    //      var tr = conn.BeginTransaction();
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
                    AddWithNullableValue(cmd, "@PasswordSalt", user.PasswordSalt ?? new byte[16]);
                    AddWithNullableValue(cmd, "@PasswordHash", user.PasswordHash ?? new byte[20]);
                    AddWithNullableValue(cmd, "@EmailConfirmed", user.EmailConfirmed);
                    AddWithNullableValue(cmd, "@Birthday", user.Birthday);
                    AddWithNullableValue(cmd, "@ValidPassword", user.ValidPassword);
                    AddWithNullableValue(cmd, "@DateCreated", DateTime.Now);
                    AddWithNullableValue(cmd, "@ReferralCode", user.ReferralCode);

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