
using Join.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Join.API.Repositories
{
    public class SQLTaskRepository : ITaskRepository
    {
        private readonly JoinDbContext dbContext;

        public SQLTaskRepository(JoinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Models.Domain.Task>> GetAllAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }
    }
}
