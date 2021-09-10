using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.DeleteActor;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenActorIdLessThanOne_Validator_ShouldBeReturnErrors(int actorId)
        {
            DeleteActorCommand command = new DeleteActorCommand(null);
            command.ActorId = actorId;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
