using FluentAssertions;
using MusicStore.Application.OrderOperations.Commands.CreateOrder;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        public void WhenAuthorIdLessThanOne_Validator_ShouldBeReturnErrors(int customerId, int musicId)
        {
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            CreateOrderModel model = new CreateOrderModel() { CustomerId = customerId, MusicId = musicId };
            command.Model = model;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
