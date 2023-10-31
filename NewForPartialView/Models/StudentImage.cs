using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewForPartialView.Models
{
    public class StudentImage
    {
        [BindProperty]
        [Key]
        public int Id { get; set; }
        [BindProperty]
        public string Url { get; set; }
        [BindProperty]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [BindProperty]
        public Stud Student { get; set; }
    }

}
