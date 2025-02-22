using Join.API.Models.Domain;
using Task = Join.API.Models.Domain.Task;

namespace Join.API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Task>> GetAllAsync();
        Task<Task?> GetByIdAsync(Guid id);
        Task<Task> CreateAsync(Task task);
        Task<Task?> UpdateAsync(Guid id, Task task);
        Task<Task?> DeleteAsync(Guid id);

    }
}
