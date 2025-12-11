using System.ComponentModel.DataAnnotations;

namespace TaskManager.Presentation.DTOs
{
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? CompletedAt { get; set; }

        public TaskManager.Domain.Enums.TaskStatus Status { get; set; } = TaskManager.Domain.Enums.TaskStatus.Pendente;
    }
}
