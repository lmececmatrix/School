using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        [DataType(DataType.Url)]
        [Required()]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Subject { get; set; }
        [Required]
        public Social Social { get; set; }

        public Teacher()
        {
            Id = 0;
            ImageUrl = "";
            Name = "";
            Subject = "";
            Social = new Social();
        }
    }
}
