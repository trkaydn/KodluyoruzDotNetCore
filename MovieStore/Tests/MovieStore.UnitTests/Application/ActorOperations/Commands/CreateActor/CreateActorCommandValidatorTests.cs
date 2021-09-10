using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.CreateActor;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel()
            {
                Name = name,
                SurName = surname
            };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel()
            {
                Name = "Test2",
                SurName = "Test2",

            };
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
