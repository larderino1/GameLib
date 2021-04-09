using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLib_Front.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class AdminPageModel : PageModel
    {
        public IEnumerable<RoleEntity>
        public void OnGet()
        {
        }
    }
}
