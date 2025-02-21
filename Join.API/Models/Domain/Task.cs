namespace Join.API.Models.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category{ get; set; }
        public DateTime Date { get; set; }
        public PriorityChoices Prio {  get; set; }
        public string? AssignedTo { get; set; }
        public StatusChoices Status { get; set; } = StatusChoices.ToDo;

        public List<Subtask> Subtasks { get; set; } = new List<Subtask>();

    }
}
