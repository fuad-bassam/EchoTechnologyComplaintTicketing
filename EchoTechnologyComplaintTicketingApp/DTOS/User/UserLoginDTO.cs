using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.DTOS.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "The Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, one digit, and a minimum length of 8 characters.")]

        public string Password { get; set; }
    }
}
