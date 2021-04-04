using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    public class MainPageModel : PageModel
    {
        private readonly ILogger<MainPageModel> _logger;

        public MainPageModel(ILogger<MainPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
