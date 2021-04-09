using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Data.Models
{
    public class UserRoles
    {
        public IdentityUser User { get; set; }
        public string Role { get; set; }
    }
}
