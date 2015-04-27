﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalBrody.Common;
using TalBrody.Entity;
using TalBrody.Logic;
using TalBrody.Util;

namespace TalBrody
{
    public partial class Project2 : System.Web.UI.Page
    {
        public string ProjectId;

        public string ShareUrl;
        public string FacebookShareUrl;
        public string TwitterShareUrl;
        public string WhatsappUrl;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InitParam()
        {
            ProjectId = "2";
            UserSession Usession = SessionUtil.GetUserSession();
            if (Usession != null)
            {
                Follower fol = Followers.GET_Follower_BY_UserId_and_project(Usession.UserId, 1);
                string ProjectName = " פרוייקט מספר שתיים שאני לא יודע מה שמו ";
                if (fol != null)
                {
                    ShareUrl = string.Format("{0}?r={1}", IOC.GetInstance<UrlBuilder>().GetProjectUrl(),
                        fol.FollowerGuid);
                }
                else
                {
                    ShareUrl = IOC.GetInstance<UrlBuilder>().GetProjectUrl();
                }
                var ShareUrlEncoded = HttpUtility.UrlEncode(ShareUrl);
                FacebookShareUrl = "https://www.facebook.com/sharer/sharer.php?u=" + HttpUtility.UrlEncode(ShareUrl) + "&display=popup&ref=plugin";
                TwitterShareUrl = "https://twitter.com/share?url=" + HttpUtility.UrlEncode(ShareUrl);
                WhatsappUrl = "whatsapp://send?text=" + ProjectName + ShareUrlEncoded;
            }
        }


        private void PopulateFollowerCountLable()
        {
            List<Follower> folloList = Followers.Get_Follower_by_Project(1);
            LblFollowerCount.Text = folloList.Count.ToString();
            UserSession usess = SessionUtil.GetUserSession();
            if (usess != null)
            {
                folloList = folloList.FindAll(o => o.ReferByUserId == usess.UserId);
                LblDiscaount.Text = ((folloList.Count + 1) * 5).ToString();
                LblDiscaount.Text = "10";
                if (folloList.Count > 0)
                {
                    string tool = "בזכותך נרשמו: " + Environment.NewLine;
                    int count = 0;
                    count = folloList.Count - 5;

                    foreach (Follower item in folloList.OrderByDescending(o => o.DateCreated).Take(5).ToList())
                    {
                        Users users = new Users();
                        User u = users.FindUserByUserId(item.UserId);

                        tool = tool + " " + u.DisplayName + "  " + Environment.NewLine;
                    }
                    if (count > 0)
                        tool = tool + Environment.NewLine + "ועוד " + count + " אנשים ";
                    DiscountDiv.Attributes.Add("title", tool);
                }
            }
        }

        private void AddFollowerCount()
        {
            try
            {
                if (Request.QueryString["r"] != null)
                {
                    string FollowerGuid = Request.QueryString["r"];
                    Followers.AddFollowerCount(FollowerGuid);
                    Follower follo = Followers.GET_Follower_BY_FollowerGuid(FollowerGuid);
                    Session.Add("UserRefId", follo.UserId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}