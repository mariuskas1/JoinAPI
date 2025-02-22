
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

        public async Task<Models.Domain.Task> CreateAsync(Models.Domain.Task task)
        {
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Domain.Task?> DeleteAsync(Guid id)
        {
            var existingTask = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTask == null)
            {
                return null;
            }

            dbContext.Tasks.Remove(existingTask);
            await dbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<List<Models.Domain.Task>> GetAllAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        public async Task<Models.Domain.Task?> GetByIdAsync(Guid id)
        {
            return await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domain.Task?> UpdateAsync(Guid id, Models.Domain.Task task)
        {
            var existingTask = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingTask == null)
            {
                return null;
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.Prio = task.Prio;
            existingTask.Date = task.Date;
            existingTask.AssignedTo = task.AssignedTo;

            await dbContext.SaveChangesAsync();
            return existingTask;

        }
    }
}
