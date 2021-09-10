

using FluentAssertions;
using MovieStore.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenBookNotFound_InvalidOperationException_ShouldBeReturn(int movieId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = movieId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek film bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeUpdated()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            UpdateMovieModel model = new UpdateMovieModel()
            {
                Name = "Movie1",
                Price = 5.75,
                DirectorId = 1,
                GenreId = 1

            };
            command.MovieId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(x => x.Name == model.Name);
            movie.Should().NotBeNull();

        }
    }
}
