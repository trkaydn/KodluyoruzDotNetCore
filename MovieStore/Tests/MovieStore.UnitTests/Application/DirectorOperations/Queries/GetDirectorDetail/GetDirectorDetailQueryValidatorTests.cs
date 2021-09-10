using FluentAssertions;
using MovieStore.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenDirectorIdLessThanOne_Validator_ShouldBeReturnErrors(int directorId)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null, null);
            query.DirectorId = directorId;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
