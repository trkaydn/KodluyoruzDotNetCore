using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.DeleteSinger;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.DeleteSinger
{
    public class DeleteSingerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenSingerIdLessThanOne_Validator_ShouldBeReturnErrors(int SingerId)
        {
            DeleteSingerCommand command = new DeleteSingerCommand(null);
            command.SingerId = SingerId;

            DeleteSingerCommandValidator validator = new DeleteSingerCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
