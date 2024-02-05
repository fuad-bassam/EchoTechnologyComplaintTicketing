using System.ComponentModel.DataAnnotations;

namespace EchoTechnologyComplaintTicketingApp.DTOS.User
{
    public class UserDto
    {
        public string UserId { get; set; }

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

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
        public bool IsAdminPrivilege { get; set; }
    }
}
