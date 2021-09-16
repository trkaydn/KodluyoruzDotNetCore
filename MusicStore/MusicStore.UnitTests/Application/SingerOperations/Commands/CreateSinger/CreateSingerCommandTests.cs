using AutoMapper;
using FluentAssertions;
using MusicStore.Application.SingerOperations.Commands.CreateSinger;
using MusicStore.DbOperations;
using MusicStore.Entities;
using MusicStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Commands.CreateSinger
{
    public class CreateSingerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateSingerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistSingerNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var singer = new Singer { Name = "Test1", SurName = "Test1" };
            _context.Singers.Add(singer);
            _context.SaveChanges();

            CreateSingerCommand command = new CreateSingerCommand(_context, _mapper);
            command.Model = new CreateSingerModel() { Name = singer.Name, SurName = singer.SurName };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Şarkıcı zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Singer_ShouldBeCreated()
        {
            CreateSingerCommand command = new CreateSingerCommand(_context, _mapper);
            CreateSingerModel model = new CreateSingerModel()
            {
                Name = "Ali",
                SurName = "Veli",
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var Singer = _context.Singers.SingleOrDefault(x => x.Name == model.Name && x.SurName == model.SurName);
            Singer.Should().NotBeNull();
        }


    }
}
