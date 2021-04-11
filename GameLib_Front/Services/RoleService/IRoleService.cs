using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Services.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRole>> GetRolesAsync();

        Task<IdentityRole> GetRoleByIdAsync(string id);
    }
}
