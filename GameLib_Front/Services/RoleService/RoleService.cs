using GameLib_Front.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleStore<IdentityRole> _store;

        public RoleService(UserDataDbContext context)
        {
            _store = new RoleStore<IdentityRole>(context);
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            return await _store.FindByIdAsync(id);
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await _store.Roles.ToListAsync();
        }
    }
}
