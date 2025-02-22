using System.ComponentModel.DataAnnotations;

namespace Join.API.Models.DTOs
{
    public class AddTaskRequestDTO
    {

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public PriorityChoices Prio { get; set; }
        public string? AssignedTo { get; set; }
        public StatusChoices Status { get; set; } = StatusChoices.ToDo;

        public List<SubtaskDTO> Subtasks { get; set; } = new List<SubtaskDTO>();
    }
}
