using Join.API.Models.Domain;
using Task = Join.API.Models.Domain.Task;

namespace Join.API.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Task>> GetAllAsync();
    }
}
