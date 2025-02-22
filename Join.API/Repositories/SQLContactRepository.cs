using Join.API.Data;
using Join.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Join.API.Repositories
{
    public class SQLContactRepository : IContactRepository
    {
        private readonly JoinDbContext dbContext;

        public SQLContactRepository(JoinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Contact>> GetAllAsync()
        {
            return await dbContext.Contacts.ToListAsync();
        }
    }
}
