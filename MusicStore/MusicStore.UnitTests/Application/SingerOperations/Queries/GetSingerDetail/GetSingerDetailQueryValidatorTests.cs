
using FluentAssertions;
using MusicStore.Application.SingerOperations.Queries.GetSingerDetail;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Queries.GetSingerDetail
{
    public class GetSingerDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenSingerIdLessThanOne_Validator_ShouldBeReturnErrors(int SingerId)
        {
            GetSingerDetailQuery query = new GetSingerDetailQuery(null, null);
            query.SingerId = SingerId;

            GetSingerDetailQueryValidator validator = new GetSingerDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
