using AutoMapper;
using FluentAssertions;
using MovieStore.Application.ActorOperations.Commands.CreateActor;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor { Name = "Test1", SurName = "Test1" };
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorModel() { Name = actor.Name, SurName = actor.SurName };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorModel model = new CreateActorModel()
            {
                Name = "Ali",
                SurName = "Veli",
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(x => x.Name == model.Name && x.SurName == model.SurName);
            actor.Should().NotBeNull();
        }


    }
}
