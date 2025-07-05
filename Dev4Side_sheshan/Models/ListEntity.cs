using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dev4Side_sheshan.Models
{
    public class ListEntity
    {
        [Key]
        public int ListId { get; set; }
        public required string Name { get; set; }
        //public string? Description { get; set; }


        [JsonIgnore]
        public UserEntity? UserEntity { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public List<TaskEntity> taskEntities { get; set; } = new();

    }
}
