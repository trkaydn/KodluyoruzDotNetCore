

using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.UpdateMusic;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.UpdateMusic
{
    public class UpdateMusicCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        public UpdateMusicCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenMusicIdLessThanOne_Validator_ShouldBeReturnErrors(int musicId)
        {
            UpdateMusicCommand command = new UpdateMusicCommand(_context);
            command.MusicId = musicId;
            command.Model = new UpdateMusicModel();

            UpdateMusicCommandValidator validator = new UpdateMusicCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("M", 0, 0, 0)]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string musicName, double price, int genreId, int singerId)
        {
            UpdateMusicCommand command = new UpdateMusicCommand(_context);
            UpdateMusicModel model = new UpdateMusicModel() { Name = musicName, Price = price, GenreId = genreId, SingerId = singerId };
            command.Model = model;

            UpdateMusicCommandValidator validator = new UpdateMusicCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
