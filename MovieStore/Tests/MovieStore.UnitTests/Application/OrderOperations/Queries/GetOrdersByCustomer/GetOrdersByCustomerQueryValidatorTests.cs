using FluentAssertions;
using MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.OrderOperations.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenCustomerIdLessThanOne_Validator_ShouldBeReturnErrors(int customerId)
        {
            GetOrdersByCustomerQuery query = new GetOrdersByCustomerQuery(null, null);
            query.CustomerId = customerId;

            GetOrdersByCustomerQueryValidator validator = new GetOrdersByCustomerQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
