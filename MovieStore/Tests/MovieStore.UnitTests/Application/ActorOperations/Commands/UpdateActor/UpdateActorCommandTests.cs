
using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.UpdateActor;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenActorNotFound_InvalidOperationException_ShouldBeReturn(int actorId)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId = actorId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek oyuncu bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeUpdated()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            UpdateActorModel model = new UpdateActorModel()
            {
                Name = "Test3",
                SurName = "Test3",
            };
            command.ActorId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Id == command.ActorId);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(model.Name);
            actor.SurName.Should().Be(model.SurName);
        }

    }
}
