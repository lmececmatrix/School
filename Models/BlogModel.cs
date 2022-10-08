
using KinderGarten.Data;
using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 20)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 200)]
        public string Description { get; set; }
        [Required]
        public Class Class { get; set; }
        public List<Comment> Comments { get; set; }
        [Required]
        public User User { get; set; }

        public BlogModel()
        {
            Id = 0;
            Name = "";
            Description = "";
            Class = new Class();
            Comments = new List<Comment>();
            User = new User();
        }
    }
}