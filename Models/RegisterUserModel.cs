using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class RegisterUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Please Enter Match Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
