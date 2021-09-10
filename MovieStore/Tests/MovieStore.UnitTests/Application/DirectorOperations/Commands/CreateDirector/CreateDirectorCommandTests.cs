using AutoMapper;
using FluentAssertions;
using MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var director = new Director() { Name = "Test9", SurName = "Test9" };
            _context.Directors.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = new CreateDirectorModel() { Name = director.Name, SurName = director.SurName };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Genre_ShouldBeCreated()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = new CreateDirectorModel() { Name = "validtest", SurName = "validtest" };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(x => x.Name == command.Model.Name && x.SurName == command.Model.SurName);
            director.Should().NotBeNull();

        }

    }
}
