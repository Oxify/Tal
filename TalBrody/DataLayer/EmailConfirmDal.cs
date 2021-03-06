﻿using System;
using System.Data;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
    public class EmailConfirmDal : BaseDal
    {
        public void StoreConfirmCode(string code, string email)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("insert into EmailConfirmCodes (Code, Email) values (@Code, @Email); ", conn);
                //      var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Email", email);

                //         cmd.Transaction = tr;
                cmd.ExecuteNonQuery();
            }
        }

        public EmailConfirmCodes FindConfirmCode(string code, string email)
        {
            if (string.IsNullOrEmpty("code"))
                throw new ArgumentNullException("code");
            if (string.IsNullOrEmpty("email"))
                throw new ArgumentNullException("email");

            using (var conn = PortalConection)
            {
                var cmd = GetCommand("select Code, Email, CreatedDate" +
                                     " from EmailConfirmCodes where Email = @Email AND Code = @Code", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                var confirmCode = Populators.Populate_EmailConfirmCodes(reader);
                return confirmCode;
            }
        }
    }
}