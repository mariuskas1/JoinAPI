using Join.API.Models.Domain;

namespace Join.API.Models.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public PriorityChoices Prio { get; set; }
        public string? AssignedTo { get; set; }
        public StatusChoices Status { get; set; } = StatusChoices.ToDo;

        public List<SubtaskDTO> Subtasks { get; set; } = new List<SubtaskDTO>();

        //public List<SubtaskDTO> Subtasks { get; set; } = new List<SubtaskDTO>();
    }
}
