using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLib_Front.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    public class DeleteUserModel : PageModel
    {
        private IUserService _userService;

        private string _name;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> OnGet(string name)
        {
            _name = name;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _userService.DeleteUser(_name);

            return RedirectToPage("./AdminPage");
        }
    }
}
