using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.CreateSinger;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.CreateSinger
{
    public class CreateSingerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            CreateSingerCommand command = new CreateSingerCommand(null, null);
            command.Model = new CreateSingerModel()
            {
                Name = name,
                SurName = surname
            };

            CreateSingerCommandValidator validator = new CreateSingerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateSingerCommand command = new CreateSingerCommand(null, null);
            command.Model = new CreateSingerModel()
            {
                Name = "Test2",
                SurName = "Test2",

            };
            CreateSingerCommandValidator validator = new CreateSingerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
