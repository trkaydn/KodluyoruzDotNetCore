

using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.DeleteMusic;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.DeleteMusic
{
    public class DeleteMusicCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenGenreIdLessThanOne_Validator_ShouldBeReturnErrors(int MusicId)
        {
            DeleteMusicCommand command = new DeleteMusicCommand(null);
            command.MusicId = MusicId;

            DeleteMusicCommandValidator validator = new DeleteMusicCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
