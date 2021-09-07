using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
    
        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            UpdateGenreModel model = new UpdateGenreModel() { Name = genreName };
            command.Model = model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
