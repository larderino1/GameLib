using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.PlatformServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class PlatformEditModel : PageModel
    {
        [BindProperty]
        public Platform Platform { get; set; }

        private readonly IPlatformServices _platformService;

        public PlatformEditModel(IPlatformServices platformService)
        {
            _platformService = platformService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            Platform = await _platformService.GetPlatformByIdAsync(id);

            if(Platform == null)
            {
                return NotFound();
            }

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
                await _platformService.UpdatePlatformAsync(Platform.Id, Platform);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Platforms");
        }
    }
}
