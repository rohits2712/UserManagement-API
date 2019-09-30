using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAPI.Domain;
using UserManagementAPI.Contracts.V1.Requests;
using FluentValidation;

namespace UserManagementAPI.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty();
            RuleFor(x => x.GivenName).NotEmpty();
            //.Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$");
        }
    }
}
