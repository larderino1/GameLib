using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Services.ModeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    public class ModeDeleteModel : PageModel
    {
        [BindProperty]
        public Mode Mode { get; set; }

        private readonly IModeServices _modeService;

        public ModeDeleteModel(IModeServices modeService)
        {
            _modeService = modeService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Mode = await _modeService.GetModeByIdAsync(id);

            if(Mode == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            await _modeService.DeleteModeAsync(id);

            return RedirectToPage("./Modes");
        }
    }
}
