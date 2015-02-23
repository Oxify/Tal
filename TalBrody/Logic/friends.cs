using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{
    public class friends
    {
        public static int Insertfriend(friend FriendObj)
        {
            friendDal dal = new friendDal();
            return dal.Insertfriend(FriendObj);
        }
    }
}