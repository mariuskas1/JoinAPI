using System.ComponentModel.DataAnnotations;

namespace Join.API.Models.DTOs
{
    public class AddContactRequestDTO
    {
        [Required]
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Color { get; set; }
        public string Info { get; set; }
    }
}
