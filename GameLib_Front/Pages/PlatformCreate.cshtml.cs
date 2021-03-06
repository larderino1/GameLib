using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.PlatformServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class PlatformCreateModel : PageModel
    {
        [BindProperty]
        public Platform Platform { get; set; }

        private readonly IPlatformServices _platformService;

        public PlatformCreateModel(IPlatformServices platformService)
        {
            _platformService = platformService;
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
                await _platformService.CreatePlatformAsync(Platform);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Platforms");
        }
    }
}
