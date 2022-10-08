using KinderGarten.Data;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace KinderGarten.Models
{
    
    public class TeacherModel
    {
        public int Id { get; set; }
        
        [Required()]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Subject { get; set; }
        [Required]
        public Social Social { get; set; }

        public TeacherModel()
        {
            Id = 0;
            Name = "";
            Subject = "";
            Social = new Social();
        }
    }
}
