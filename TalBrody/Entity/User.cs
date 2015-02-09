using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalBrody.Entity
{
    public class User
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public long FaceBookId { get; set; }
        public string FacebookAccessToken { get; set; }
		public string TwitterId { get; set; }
        public string TwitterToken { get; set; }
        public string TwitterSecret { get; set; }
        public string TwitterAccessToken { get; set; }
		public string ReferancedBy { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
	    public bool EmailConfirmed { get; set; }
        public DateTime Birthday { get; set; }
        public bool ValidPassword { get; set; }
	}
}