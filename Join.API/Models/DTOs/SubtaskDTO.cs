using System.ComponentModel.DataAnnotations.Schema;

namespace Join.API.Models.DTOs
{
    public class SubtaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public StatusChoices StatusChoices { get; set; }
        public Guid TaskId { get; set; }
    }
}
