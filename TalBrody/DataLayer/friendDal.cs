using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalBrody.Entity;

namespace TalBrody.DataLayer
{
    public class friendDal : BaseDal
    {
        public int Insertfriend(friend FriendObj)
        {
            int friendId = 0;
            using (var conn = PortalConection)
            {
                conn.Open();
                var cmd = GetCommand("INSERT INTO [Friends] ([Userid],[FriendId]) VALUES(@UserId,@FriendId); ", conn);

                var tr = conn.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserId", FriendObj.Userid);
                cmd.Parameters.AddWithValue("@FriendId", FriendObj.FriendId);

                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();

                cmd = GetCommand("SELECT @@IDENTITY AS ID", conn);
                cmd.Transaction = tr;
                object o = cmd.ExecuteScalar();
                friendId = Convert.ToInt32(o);

                tr.Commit();
            }
            return friendId;
        }
    }
}