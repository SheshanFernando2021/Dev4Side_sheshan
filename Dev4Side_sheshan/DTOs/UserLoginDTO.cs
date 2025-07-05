using System.ComponentModel.DataAnnotations;

namespace Dev4Side_sheshan.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
