

using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.UpdateMusic;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.UpdateMusic
{
    public class UpdateMusicCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        public UpdateMusicCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }


        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenBookNotFound_InvalidOperationException_ShouldBeReturn(int musicId)
        {
            UpdateMusicCommand command = new UpdateMusicCommand(_context);
            command.MusicId = musicId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek şarkı bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Music_ShouldBeUpdated()
        {
            UpdateMusicCommand command = new UpdateMusicCommand(_context);
            UpdateMusicModel model = new UpdateMusicModel()
            {
                Name = "Music1",
                Price = 5.75,
                SingerId = 1,
                GenreId = 1

            };
            command.MusicId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var Music = _context.Musics.SingleOrDefault(x => x.Name == model.Name);
            Music.Should().NotBeNull();

        }
    }
}
