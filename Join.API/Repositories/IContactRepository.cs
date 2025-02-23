using Join.API.Models.Domain;

namespace Join.API.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(Guid id);
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact?> UpdateAsync(Guid id, Contact contact);
        Task<Contact?> DeleteAsync(Guid id);
    }
}
