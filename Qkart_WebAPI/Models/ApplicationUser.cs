using Microsoft.AspNetCore.Identity;

namespace Qkart_WebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
