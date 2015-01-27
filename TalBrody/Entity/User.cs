using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fblogin.Entity
{
	public class User
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public string FaceBookId { get; set; }
		public string TwittId { get; set; }
		public string Password { get; set; }
		public string ReferanceBy { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
	}
}