using FluentValidation;


namespace MusicStore.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().GreaterThan(0);

        }
    }
}
