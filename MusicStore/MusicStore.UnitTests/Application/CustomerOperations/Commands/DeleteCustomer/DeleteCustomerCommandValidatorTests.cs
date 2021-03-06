using FluentAssertions;
using MusicStore.Application.CustomerOperations.Commands.DeleteCustomer;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenCustomerIdLessThanOne_Validator_ShouldBeReturnErrors(int customerId)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = customerId;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
