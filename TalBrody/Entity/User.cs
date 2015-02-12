using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
    public class User
	{
		public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
		public long FacebookId { get; set; }
        public string FacebookAccessToken { get; set; }
		public string TwitterId { get; set; }
        public string TwitterToken { get; set; }
        public string TwitterSecret { get; set; }
        public string TwitterAccessToken { get; set; }
		public string ReferredBy { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
	    public bool EmailConfirmed { get; set; }

        private DateTime birthday = new DateTime(1900, 1, 1);
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = DefaultDateTime(value); }         
        }

        public bool ValidPassword { get; set; }
        private DateTime dateCreated = new DateTime(1900,1,1);
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = DefaultDateTime(value); }
        }
        private DateTime lastLogin = new DateTime(1900, 1, 1);
        public DateTime LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = DefaultDateTime(value); }
        }
        public string ReferralCode { get; set; }

        private DateTime DefaultDateTime(DateTime value)
        {
            if (value < new DateTime(1900, 1, 1))
            {
                return new DateTime(1900, 1, 1);
            }
            return value;
        }
	}
}