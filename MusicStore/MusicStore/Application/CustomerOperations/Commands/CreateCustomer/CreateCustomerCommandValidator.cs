using FluentValidation;

namespace MusicStore.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Model.Password).MinimumLength(5);
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.SurName).MinimumLength(2);
        }
    }
}
