using System.ComponentModel.DataAnnotations;

namespace Dev4Side_sheshan.Models
{
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public ListEntity ListEntity { get; set; } = null!;
        public int ListId { get; set; }
    }
}
