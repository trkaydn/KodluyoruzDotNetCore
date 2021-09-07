using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("A")]
        [InlineData("")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string genreName)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel() { Name = genreName };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Deneme1")]
        [InlineData("Deneme2")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string genreName)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel() { Name = genreName };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }

    }
}
