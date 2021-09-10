using FluentValidation;
namespace MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryValidator : AbstractValidator<GetOrdersByCustomerQuery>
    {
        public GetOrdersByCustomerQueryValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
        }
    }
}
