using System.ComponentModel.DataAnnotations;

namespace Dev4Side_sheshan.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = null!;
        public string username => Email.Contains('@') ? Email.Split('@')[0] : Email;
    }
}
