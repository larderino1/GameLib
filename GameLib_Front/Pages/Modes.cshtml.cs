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
    public class ModesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Mode> Modes { get; set; }

        private readonly IModeServices _modeService;

        public ModesModel(IModeServices modeService)
        {
            _modeService = modeService;
        }

        public async Task OnGet()
        {
            Modes = await _modeService.GetModeListAsync();

            if (Modes == null)
            {
                Modes = new List<Mode>();
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                Modes = Modes.Where(s => s.Name.Contains(SearchString));
            }
        }
    }
}
