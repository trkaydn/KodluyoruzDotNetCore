using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.UpdateSinger;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.UpdateSinger
{
    public class UpdateSingerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateSingerCommand command = new UpdateSingerCommand(null);
            UpdateSingerModel model = new UpdateSingerModel() { Name = name, SurName = surname };
            command.Model = model;

            UpdateSingerCommandValidator validator = new UpdateSingerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
