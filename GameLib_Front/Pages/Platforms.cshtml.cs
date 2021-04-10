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
    public class PlatformsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Platform> Platforms { get; set; }

        private readonly IPlatformServices _platformService;

        public PlatformsModel(IPlatformServices platformService)
        {
            _platformService = platformService;
        }

        public async Task OnGet()
        {
            Platforms = await _platformService.GetPlatformsListAsync();

            if(Platforms == null)
            {
                Platforms = new List<Platform>();
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                Platforms = Platforms.Where(s => s.Name.Contains(SearchString));
            }
        }
    }
}
