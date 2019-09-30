using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Domain
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot exceed more than 50 characters")]
        public string GivenName { get; set; }
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", ErrorMessage = "Invalid Email")]
        public string EmailAddress { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public Guid ManagerId { get; set; }

    }
}
