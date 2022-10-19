using EmployeeContacts.Api.Models;
using EmployeeContacts.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeContacts.Api.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsRepository;

        public ContactsController(IContactsService contactsRepository)
        {
            _contactsRepository = contactsRepository ??
                throw new ArgumentNullException(nameof(contactsRepository));
        }


        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactsRepository.GetContactsAsync();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public async Task<Contact> GetContact(long id)
        {
            return await _contactsRepository.GetContactAsync(id);
        }

        [HttpGet("search")]
        public async Task<List<Contact>> FindContacts([FromQuery] ContactFind findRequest)
        {
            return await _contactsRepository.FindContactsAsync(findRequest);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(ContactRequest request)
        {
            var newContact = await _contactsRepository.AddContact(request);

            return CreatedAtRoute("GetContact", new { id = newContact.ContactID }, newContact);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateContact(long id, ContactRequest request)
        {

            var updatedContact = await _contactsRepository.UpdateContact(id, request);

            return CreatedAtRoute("GetContact", new { id = id }, updatedContact);
        }
    }
}
