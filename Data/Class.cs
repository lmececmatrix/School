
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Data
{
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  StartAge { get; set; }
        public int EndAge { get; set; }
        public int TotalSeats { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float TutionFee { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
