namespace Dev4Side_sheshan.DTOs
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public int ListId { get; set; }
    }
}
