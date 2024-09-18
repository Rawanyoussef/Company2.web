using System.ComponentModel.DataAnnotations;

namespace Company.web.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemmberMe { get; internal set; }
    }
}
