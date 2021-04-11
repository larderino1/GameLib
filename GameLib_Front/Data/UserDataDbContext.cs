using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameLib_Front.Data
{
    public class UserDataDbContext : IdentityDbContext
    {
        public UserDataDbContext(DbContextOptions<UserDataDbContext> options)
            : base(options)
        {
        }
    }
}
