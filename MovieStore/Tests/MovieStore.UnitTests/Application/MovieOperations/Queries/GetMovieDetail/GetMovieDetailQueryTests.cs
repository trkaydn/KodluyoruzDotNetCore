

using AutoMapper;
using FluentAssertions;
using MovieStore.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenMovieNotFound_InvalidOperationException_ShouldBeReturn(int movieId)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = movieId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir film bulunamadı.");
        }
    }
}
