
using FluentAssertions;
using MovieStore.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("A", "A", "aa@hotmail.com", "A")]
        [InlineData("BB", "BB", "bb@hotmail.com", "BB")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel() { Name = name, SurName = surname, Email = email, Password = password };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("deneme6", "deneme6", "invalidmail1", "deneme6")]
        [InlineData("deneme7", "deneme7", "invalidmail2", "deneme7")]
        public void WhenInvalidMailAreGiven_Validator_ShouldNotBeReturnError(string name, string surname, string email, string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel() { Name = name, SurName = surname, Email = email, Password = password };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("deneme8", "deneme8", "deneme8@hotmail.com", "deneme8")]
        [InlineData("deneme9", "deneme9", "deneme9@hotmail.com", "deneme9")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string name, string surname, string email, string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel() { Name = name, SurName = surname, Email = email, Password = password };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
