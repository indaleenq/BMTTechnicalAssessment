using System.ComponentModel.DataAnnotations;

namespace EmployeeContacts.Api.Models
{
    public class ContactRequest
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "First Name is required.")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; } = String.Empty;

        public string MobileNumber { get; set; } = String.Empty;


        [EmailAddress(ErrorMessage = "Email Address inputted is not a valid e-mail address.")]
        public string EmaillAddress { get; set; } = String.Empty;
    }
}
