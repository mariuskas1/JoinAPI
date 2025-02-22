using Join.API.Models.Domain;

namespace Join.API.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
    }
}
