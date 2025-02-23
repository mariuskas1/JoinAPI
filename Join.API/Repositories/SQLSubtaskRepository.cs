using Join.API.Data;
using Join.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Join.API.Repositories
{
    public class SQLSubtaskRepository : ISubtaskRepository
    {
        private readonly JoinDbContext dbContext;

        public SQLSubtaskRepository(JoinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Subtask?> UpdateAsync(Guid id, Subtask subtask)
        {
            var existingSubtask = await dbContext.Subtasks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingSubtask == null)
            {
                return null;
            }
            existingSubtask.Status = subtask.Status;
            await dbContext.SaveChangesAsync();
            return subtask;
        }
    }
}
