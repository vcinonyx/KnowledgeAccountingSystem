using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
