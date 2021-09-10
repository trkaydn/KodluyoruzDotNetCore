using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.DeleteActor;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenAuthorNotFound_InvalidOperationException_ShouldBeReturn(int authorId)
        {

            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId= authorId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek oyuncu bulunamadı");
        }
    }
}
