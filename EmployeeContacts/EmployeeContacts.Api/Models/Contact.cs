using System.ComponentModel.DataAnnotations;

namespace EmployeeContacts.Api.Models
{
    public class Contact
    {
        [Key]
        public long ContactID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [MinLength(11)]
        public string? MobileNumber { get; set; }

        [Required]
        [EmailAddress]

        public string EmailAddress { get; set; }
    }
}
