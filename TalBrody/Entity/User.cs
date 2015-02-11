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
        public DateTime Birthday { get; set; }
        public bool ValidPassword { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastLogin { get; set; }
        public string ReferralCode { get; set; }
	}
}