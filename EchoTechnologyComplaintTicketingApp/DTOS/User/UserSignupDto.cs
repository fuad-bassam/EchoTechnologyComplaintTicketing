using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.DTOS.User
{
    public class UserSignupDto
    {

        [MaxLength(100, ErrorMessage = "The field name English must not exceed 100 characters.")]
        [RegularExpression("^[a-zA-Z _-]*$", ErrorMessage = "English characters, spaces, underscores and hyphens are the only allowed.")]
        [Required(ErrorMessage = "The english name is Required")]
        public string NameEn { get; set; }

        [MaxLength(100, ErrorMessage = "The field code name Arabic must not exceed 50 characters.")]
        [RegularExpression("^[\\p{IsArabic} _-]*$", ErrorMessage = "Arabic characters, spaces, underscores and hyphens are the only allowed.")]
        [Required(ErrorMessage = "the arabic name is Required")]
        public string NameAr { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "The Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]

        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, one digit, and a minimum length of 8 characters.")]
        public string Password { get; set; }
    }
}
