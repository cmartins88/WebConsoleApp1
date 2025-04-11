using Microsoft.AspNetCore.Identity;

namespace Project1_Angular.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}