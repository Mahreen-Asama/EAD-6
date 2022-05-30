using System;
using System.Collections.Generic;

namespace WebApplication3
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
