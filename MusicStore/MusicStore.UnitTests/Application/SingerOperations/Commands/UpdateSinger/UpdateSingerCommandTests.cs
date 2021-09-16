
using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.UpdateSinger;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.UpdateSinger
{
    public class UpdateSingerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        public UpdateSingerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenSingerNotFound_InvalidOperationException_ShouldBeReturn(int SingerId)
        {
            UpdateSingerCommand command = new UpdateSingerCommand(_context);
            command.SingerId = SingerId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek şarkıcı bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeUpdated()
        {
            UpdateSingerCommand command = new UpdateSingerCommand(_context);
            UpdateSingerModel model = new UpdateSingerModel()
            {
                Name = "Test3",
                SurName = "Test3",
            };
            command.SingerId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var Singer = _context.Singers.SingleOrDefault(x => x.Id == command.SingerId);
            Singer.Should().NotBeNull();
            Singer.Name.Should().Be(model.Name);
            Singer.SurName.Should().Be(model.SurName);
        }

    }
}
