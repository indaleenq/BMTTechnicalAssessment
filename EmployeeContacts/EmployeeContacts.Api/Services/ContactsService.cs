using EmployeeContacts.Api.DbContexts;
using EmployeeContacts.Api.Models;

namespace EmployeeContacts.Api.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ContactsContext _context;

        public ContactsService(ContactsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool ContactExistsAsync(long contactId)
        {
            return GetContactAsync(contactId) != null;
        }

        //gets a contact based on contact id
        public Task<Contact?> GetContactAsync(long contactId)
        {
            _context.GetContacts();
            return Task.FromResult(_context.Contacts.FirstOrDefault(x => x.ContactID == contactId));
        }

        //gets all contacts
        public Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return Task.FromResult(_context.GetContacts());
        }

        //Find a contact based on the request
        public Task<List<Contact>> FindContactsAsync(ContactFind findRequest)
        {
            _context.GetContacts();
            List<Contact> result = new List<Contact>();

            if (findRequest.ContactID > 0 )
            {
                result.AddRange(_context.Contacts.FindAll(x => x.ContactID == findRequest.ContactID));
            }

            if (!string.IsNullOrWhiteSpace(findRequest.FirstName))
            {
                result.AddRange(_context.Contacts.FindAll(x => x.FirstName == findRequest.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(findRequest.LastName))
            {
                result.AddRange(_context.Contacts.FindAll(x => x.LastName == findRequest.LastName));
            }

            if (!string.IsNullOrWhiteSpace(findRequest.CompanyName))
            {
                result.AddRange(_context.Contacts.FindAll(x => x.CompanyName == findRequest.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(findRequest.EmailAddress))
            {
                result.AddRange(_context.Contacts.FindAll(x => x.EmailAddress == findRequest.EmailAddress));
            }

            return Task.FromResult(result);
        }

        public Task<Contact?> AddContact(ContactRequest request)
        {
            long contactId = _context.Contacts.Max(x => x.ContactID);
            contactId++;
            var result =  _context.AddContact(new Contact
            {
                ContactID = Convert.ToInt64(contactId),
                FirstName = request.FirstName,
                LastName = request.LastName,
                CompanyName = request.CompanyName,
                EmailAddress = request.EmaillAddress,
                MobileNumber = request.MobileNumber
            });

            if (result > 0)
            {
                return GetContactAsync(result);
            }
            else
            {
                Contact dummy = new Contact();
                return Task.FromResult(dummy);
            }
        }
        

        public Task<Contact?> UpdateContact(long id, ContactRequest request)
        {
            if (Convert.ToBoolean(ContactExistsAsync(id)))
            {
                var contactToUpdate = new Contact()
                {
                    ContactID = id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    CompanyName = request.CompanyName,
                    MobileNumber = request.MobileNumber,
                    EmailAddress = request.EmaillAddress
                };
                var result = _context.UpdateContact(contactToUpdate);
                return result > 0 ? GetContactAsync(result) : Task.FromResult(new Contact());
            }
            else
            {
                return Task.FromResult(new Contact());
            }
        }

        
    }
}
