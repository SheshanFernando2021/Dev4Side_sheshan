using System.ComponentModel.DataAnnotations;

namespace Dev4Side_sheshan.Models
{
    public class ListEntity
    {
        [Key]
        public int ListId { get; set; }
        public required string Name { get; set; }
        //public string? Description { get; set; }


        public UserEntity UserEntity { get; set; } = null!;
        public int UserId { get; set; }

        public List<TaskEntity> taskEntities { get; set; } = new();

    }
}
