using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.CreateMusic;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.CreateMusic
{
    public class CreateMusicCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("M", 0, 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string musicName, double price, int genreId, int singerId)
        {
            CreateMusicCommand command = new CreateMusicCommand(null, null);
            command.Model = new CreateMusicModel() { Name = musicName, Price = price, GenreId = genreId, SingerId = singerId };

            CreateMusicCommandValidator validator = new CreateMusicCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Music1", 4.5, 1, 1)]
        [InlineData("Music2", 3.5, 2, 1)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string musicName, double price, int genreId, int singerId)
        {
            CreateMusicCommand command = new CreateMusicCommand(null, null);
            command.Model = new CreateMusicModel() { Name = musicName, Price = price, GenreId = genreId, SingerId = singerId };

            CreateMusicCommandValidator validator = new CreateMusicCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }
    }
}
