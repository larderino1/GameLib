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
    public class PlatformDeleteModel : PageModel
    {
        [BindProperty]
        public Platform Platform { get; set; }

        private readonly IPlatformServices _platformService;

        public PlatformDeleteModel(IPlatformServices platformService)
        {
            _platformService = platformService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Platform = await _platformService.GetPlatformByIdAsync(id);

            if (Platform == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            await _platformService.DeletePlatformAsync(id);

            return RedirectToPage("./Platforms");
        }
    }
}
