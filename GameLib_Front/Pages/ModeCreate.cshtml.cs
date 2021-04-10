using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.ModeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class ModeCreateModel : PageModel
    {
        [BindProperty]
        public Mode Mode { get; set; }

        private readonly IModeServices _modeService;

        public ModeCreateModel(IModeServices modeService)
        {
            _modeService = modeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _modeService.CreateModeAsync(Mode);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Modes");
        }
    }
}
