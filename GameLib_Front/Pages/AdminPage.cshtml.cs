using GameLib_Front.Constants;
using GameLib_Front.Data.Models;
using GameLib_Front.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class AdminPageModel : PageModel
    {
        public IEnumerable<UserRoles> Users { get; set; }

        private readonly IUserService _userService;

        public AdminPageModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            Users = await _userService.GetUsersWithRoles();
            return Page();
        }
    }
}
