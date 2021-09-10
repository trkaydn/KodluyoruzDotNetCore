using FluentAssertions;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("M", 0, 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string movieName, double price, int genreId, int directorId)
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel() { Name = movieName, Price = price, GenreId = genreId, DirectorId = directorId };

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Movie1", 4.5, 1, 1)]
        [InlineData("Movie2", 3.5, 2, 1)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string movieName, double price, int genreId, int directorId)
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel() { Name = movieName, Price = price, GenreId = genreId, DirectorId = directorId };

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }
    }
}
