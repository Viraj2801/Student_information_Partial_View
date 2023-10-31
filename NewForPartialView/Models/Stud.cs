using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NewForPartialView.Models
{
    public class Stud
    {
        [BindProperty]
        [Key]
        public int Id { get; set; }
        [Required]
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Roll { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string Address { get; set; }

        //public string ImageUrl { get; set; }
        //public List<string> ImageUrls { get; set; }
        [BindProperty]
        [ValidateNever]
        public List<StudentImage> ImageUrl { get; set; }
    }
}
