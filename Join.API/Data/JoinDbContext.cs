using Join.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Task = Join.API.Models.Domain.Task;


namespace Join.API.Data
{
    public class JoinDbContext : DbContext
    {
        public JoinDbContext(DbContextOptions<JoinDbContext> dbContextOptions): base(dbContextOptions) 
        {
            
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
