using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
