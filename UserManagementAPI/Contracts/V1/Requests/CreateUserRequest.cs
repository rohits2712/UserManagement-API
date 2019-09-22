using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Contracts.V1.Requests
{
    public class CreateUserRequest
    {
        public Guid Id { get; set; }
        public string GivenName { get; set; }

        public string Surname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ManagerId { get; set; }
    }
}
