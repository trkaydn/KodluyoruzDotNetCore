using FluentAssertions;
using MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("A", "A")]
        [InlineData("B", "")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surName)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel() { Name = name, SurName = surName };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Deneme1", "Deneme1")]
        [InlineData("Deneme2", "Deneme2")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string name, string surName)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel() { Name = name, SurName = surName };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }
    }
}
