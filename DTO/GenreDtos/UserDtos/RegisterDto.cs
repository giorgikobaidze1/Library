using System.ComponentModel.DataAnnotations;

namespace Library1.DTO.GenreDtos.UserDtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        //[StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
