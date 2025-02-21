using System.ComponentModel.DataAnnotations.Schema;

namespace Join.API.Models.Domain
{
    public class Subtask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public StatusChoices StatusChoices { get; set; }

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
