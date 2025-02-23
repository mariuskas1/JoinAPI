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

        public async Task<Contact> CreateAsync(Contact contact)
        {
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact?> DeleteAsync(Guid id)
        {
            var existingContact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingContact == null)
            {
                return null;
            }
            dbContext.Contacts.Remove(existingContact);
            await dbContext.SaveChangesAsync();
            return existingContact;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact?> UpdateAsync(Guid id, Contact contact)
        {
            var existingContact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingContact == null)
            {
                return null;
            }
            
            existingContact.Name = contact.Name;
            existingContact.Mail = contact.Mail;
            existingContact.Phone = contact.Phone;  
            existingContact.Info = contact.Info;

            await dbContext.SaveChangesAsync();
            return existingContact;

        }
    }
}
