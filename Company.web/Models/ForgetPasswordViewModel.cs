using System.ComponentModel.DataAnnotations;

namespace Company.web.Models
{
    public class ForgetPassWordViewModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
