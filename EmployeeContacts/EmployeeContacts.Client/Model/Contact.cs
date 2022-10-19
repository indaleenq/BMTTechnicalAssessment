using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeContacts.Client.Model
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
