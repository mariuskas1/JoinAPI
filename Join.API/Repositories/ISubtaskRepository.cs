using Join.API.Models.Domain;

namespace Join.API.Repositories
{
    public interface ISubtaskRepository
    {
        Task<Subtask?> UpdateAsync(Guid id, Subtask subtask);
    }
}
