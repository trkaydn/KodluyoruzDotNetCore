

using FluentAssertions;
using MovieStore.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string name, string surName)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            UpdateDirectorModel model = new UpdateDirectorModel() { Name = name, SurName = surName };
            command.Model = model;

            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
