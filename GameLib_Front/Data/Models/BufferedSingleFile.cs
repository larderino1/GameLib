using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GameLib_Front.Data.Models
{
    public class BufferedSingleFile
    {
        [Required]
        [Display(Name = "FileManager")]
        public IFormFile FormFile { get; set; }
    }
}
