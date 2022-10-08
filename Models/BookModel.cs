using KinderGarten.Data;
using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter name contain characters from 3 to 100")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter email")]
        [EmailAddress(ErrorMessage ="Please Enter valid email")]
        public string Email { get; set; }
        [Required]
        public int ClassID { get; set; }

        public BookModel()
        {
            Id = -1;
            Name = "";
            Email = "";
        }
    }
}
