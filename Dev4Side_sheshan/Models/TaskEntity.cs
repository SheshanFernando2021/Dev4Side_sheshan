using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dev4Side_sheshan.Models
{
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        [JsonIgnore]
        public ListEntity? ListEntity { get; set; }
        public int ListId { get; set; }
    }
}
