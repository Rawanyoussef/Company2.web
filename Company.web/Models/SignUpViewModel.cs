

using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
    {
        public class SignUpViewModel
        {
            [Required(ErrorMessage = "Please enter your first name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter your last name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Please enter your email address")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please enter a password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Please confirm your password")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; }

            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
                ErrorMessage = "Password must be at least 8 characters long, include uppercase, lowercase, a number, and a special character")]
            public string PasswordRegexValidation { get; set; }
        }
    }



