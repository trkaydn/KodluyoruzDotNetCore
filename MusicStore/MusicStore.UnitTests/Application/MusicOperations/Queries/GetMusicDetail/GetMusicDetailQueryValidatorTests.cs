

using FluentAssertions;
using MusicStore.Application.MusicOperations.Queries.GetMusicDetail;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Queries.GetMusicDetail
{
    public class GetMusicDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenMusicIdLessThanOne_Validator_ShouldBeReturnErrors(int musicId)
        {
            GetMusicDetailQuery query = new GetMusicDetailQuery(null, null);
            query.MusicId = musicId;

            GetMusicDetailQueryValidator validator = new GetMusicDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
