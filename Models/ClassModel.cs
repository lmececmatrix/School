using KinderGarten;
using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public int StartAge { get; set; }
        [Required]
        public int EndAge { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public float TutionFee { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}
