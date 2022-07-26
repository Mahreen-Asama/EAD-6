using Microsoft.AspNetCore.Identity;

namespace Asp.Net_Core_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; }
    }
}
