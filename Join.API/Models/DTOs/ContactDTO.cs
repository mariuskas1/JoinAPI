namespace Join.API.Models.DTOs
{
    public class ContactDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Color { get; set; }
        public string Info { get; set; }
    }
}
