

using AutoMapper;
using FluentAssertions;
using MovieStore.Application.OrderOperations.Commands.CreateOrder;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        public void WhenAuthorIdLessThanOne_Validator_ShouldBeReturnErrors(int customerId, int movieId)
        {
            CreateOrderCommand command = new CreateOrderCommand(null,null);
            CreateOrderModel model = new CreateOrderModel() { CustomerId = customerId, MovieId = movieId };
            command.Model = model;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
