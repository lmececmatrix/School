using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Data
{
    public class Social
    { 
        public short Id { get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string LinkFacebook { get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string LinkedTwitter { get; set; }
        [DataType(DataType.Url)]
        [Required]
        public string LinedLinkedIn { get; set; }

        public Social() { 
        }
    }
}
