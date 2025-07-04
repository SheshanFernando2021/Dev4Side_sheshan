using System.ComponentModel.DataAnnotations;

namespace Dev4Side_sheshan.Models
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public required string Email { get; set; }
        public string? PasswordHash { get; set; }

        


        public List<ListEntity> listEntities { get; set; } = new();
    }
}
