using AutoMapper;
using FluentAssertions;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var movie = new Movie() { Name = "TestMovie" };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = new CreateMovieModel() { Name = movie.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeCreated()
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            CreateMovieModel model = new CreateMovieModel()
            {
                Name = "Movie1",
                Price = 5.75,
                DirectorId = 1,
                GenreId = 1

            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(x => x.Name == model.Name);
            movie.Should().NotBeNull();

        }
    }
}
