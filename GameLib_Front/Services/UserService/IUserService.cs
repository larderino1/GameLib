using GameLib_Front.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<IdentityUser>> GetAllUsers();
        Task DeleteUser(string userName);
        Task<IdentityUser> GetUserByName(string userName);
        Task UpdateUserRole(string userName, string roleOld, string roleNew);
        Task UpdateUserEmail(string userName, string email);
        Task<IEnumerable<UserRoles>> GetUsersWithRoles();
    }
}
