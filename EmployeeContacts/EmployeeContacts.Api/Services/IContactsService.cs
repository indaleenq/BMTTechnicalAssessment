using EmployeeContacts.Api.Models;

namespace EmployeeContacts.Api.Services
{
    public interface IContactsService
    {
        Task<Contact?> GetContactAsync(long contactId);
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact?> AddContact(ContactRequest request);
        Task<Contact?> UpdateContact(long id, ContactRequest request);
        bool ContactExistsAsync(long contactId);
        Task<List<Contact>> FindContactsAsync(ContactFind findRequest);
    }
}
