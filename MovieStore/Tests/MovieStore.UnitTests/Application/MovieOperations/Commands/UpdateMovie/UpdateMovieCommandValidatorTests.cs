

using FluentAssertions;
using MovieStore.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateMovieCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenMovieIdLessThanOne_Validator_ShouldBeReturnErrors(int movieId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = movieId;
            command.Model = new UpdateMovieModel();

            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("M", 0, 0, 0)]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string movieName, double price, int genreId, int directorId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            UpdateMovieModel model = new UpdateMovieModel() { Name = movieName,Price=price,GenreId=genreId,DirectorId=directorId };
            command.Model = model;

            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
