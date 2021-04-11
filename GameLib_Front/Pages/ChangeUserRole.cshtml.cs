using GameLib_Front.Constants;
using GameLib_Front.Services.RoleService;
using GameLib_Front.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class ChangeUserRoleModel : PageModel
    {
        [BindProperty]
        public IdentityUser User { get; set; }

        [BindProperty]
        public IdentityRole Role { get; set; }

        private readonly IUserService _userService;

        private readonly IRoleService _roleService;

        private static string _role;

        private static string _name;

        public ChangeUserRoleModel(
            IUserService userService,
            IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGet(string name, string role)
        {
            _name = name;

            _role = role;

            User = await _userService.GetUserByName(name);

            var roles = await _roleService.GetRolesAsync();

            ViewData["Roles"] = new SelectList(roles, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPost(IdentityRole role)
        {
            var userRole = await _roleService.GetRoleByIdAsync(role.Id);

            await _userService.UpdateUserRole(_name, _role, role.Name);

            return RedirectToPage("./AdminPage");
        }
    }
}
