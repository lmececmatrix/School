using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Data
{
    public class Book
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int ClassID { get; set; }
        public Class Class { get; set; }

        public Book()
        {
            Id = -1;
            Name = "";
            Email = "";
            Class = null;
        }
    }
}
