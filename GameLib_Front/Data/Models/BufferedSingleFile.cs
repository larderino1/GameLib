using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Data.Models
{
    public class BufferedSingleFile
    {
        [Required]
        [Display(Name = "FileManager")]
        public IFormFile FormFile { get; set; }
    }
}
