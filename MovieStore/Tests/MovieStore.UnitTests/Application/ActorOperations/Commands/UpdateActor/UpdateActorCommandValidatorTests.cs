

using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.UpdateActor;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            UpdateActorModel model = new UpdateActorModel() { Name = name, SurName = surname };
            command.Model = model;

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
