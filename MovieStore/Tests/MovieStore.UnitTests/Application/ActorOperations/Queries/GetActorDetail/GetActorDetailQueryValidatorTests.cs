
using FluentAssertions;
using MovieStore.Application.ActorOperations.Queries.GetActorDetail;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenActorIdLessThanOne_Validator_ShouldBeReturnErrors(int actorId)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null, null);
            query.ActorId = actorId;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
