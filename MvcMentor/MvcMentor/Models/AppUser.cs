using Microsoft.AspNetCore.Identity;

namespace MvcMentor.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}