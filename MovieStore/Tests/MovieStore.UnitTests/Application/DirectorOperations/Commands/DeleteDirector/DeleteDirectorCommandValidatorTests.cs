

using FluentAssertions;
using MovieStore.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDirectorIdLessThanOne_Validator_ShouldBeReturnErrors(int directorId)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId = directorId;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
