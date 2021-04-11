using Microsoft.AspNetCore.Identity;

namespace GameLib_Front.Data.Models
{
    public class UserRoles
    {
        public IdentityUser User { get; set; }
        public string Role { get; set; }
    }
}
