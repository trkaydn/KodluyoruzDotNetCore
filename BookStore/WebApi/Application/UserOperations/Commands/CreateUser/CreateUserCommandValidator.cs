using FluentValidation;
using System;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Model.Password).NotEmpty().MinimumLength(2);
            
        }
    }
}
