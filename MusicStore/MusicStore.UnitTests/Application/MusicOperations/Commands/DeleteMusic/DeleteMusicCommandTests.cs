

using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.DeleteMusic;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.DeleteMusic
{
    public class DeleteMusicCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        public DeleteMusicCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenMusicNotFound_InvalidOperationException_ShouldBeReturn(int musicId)
        {
            DeleteMusicCommand command = new DeleteMusicCommand(_context);
            command.MusicId = musicId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek şarkı bulunamadı");
        }
    }
}
