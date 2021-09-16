using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.DeleteSinger;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.DeleteSinger
{
    public class DeleteSingerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;

        public DeleteSingerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenAuthorNotFound_InvalidOperationException_ShouldBeReturn(int authorId)
        {

            DeleteSingerCommand command = new DeleteSingerCommand(_context);
            command.SingerId = authorId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek şarkıcı bulunamadı");
        }
    }
}
