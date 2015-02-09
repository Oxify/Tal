using System;

namespace TalBrody.Entity
{
    public class EmailConfirmCodes
    {
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}