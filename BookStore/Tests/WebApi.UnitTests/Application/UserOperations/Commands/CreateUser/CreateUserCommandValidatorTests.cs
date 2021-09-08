using FluentAssertions;
using System;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("A","B","C","D")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surName, string eMail, string password)
        {
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel()
            {
                Name = name,
                Surname=surName,
                Email=eMail,
                Password=password

            };

            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateUserCommand command = new CreateUserCommand(null, null);
            command.Model = new CreateUserModel()
            {
                Name = "validname",
                Surname = "validsurname",
                Email = "valid@hotmail.com",
                Password = "validpass"

            };
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }
    }
}
