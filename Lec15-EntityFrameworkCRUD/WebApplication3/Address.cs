using System;
using System.Collections.Generic;

namespace WebApplication3
{
    public partial class Address
    {
        public int Id { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? UserEmail { get; set; }

        public virtual User? UserEmailNavigation { get; set; }
    }
}
