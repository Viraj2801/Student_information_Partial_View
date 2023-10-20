using System.ComponentModel.DataAnnotations;

namespace NewForPartialView.Models
{
    public class Stud
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Roll { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }



    }
}
