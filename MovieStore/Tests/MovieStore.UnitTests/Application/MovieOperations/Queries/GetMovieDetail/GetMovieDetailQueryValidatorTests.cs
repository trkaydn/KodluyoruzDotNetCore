

using FluentAssertions;
using MovieStore.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenMovieIdLessThanOne_Validator_ShouldBeReturnErrors(int movieId)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(null, null);
            query.MovieId = movieId;

            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
