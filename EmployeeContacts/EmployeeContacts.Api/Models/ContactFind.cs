using System.ComponentModel.DataAnnotations;

namespace EmployeeContacts.Api.Models
{
    public class ContactFind
    {
        public long ContactID { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? CompanyName { get; set; }

        public string? EmailAddress { get; set; }
    }
}
