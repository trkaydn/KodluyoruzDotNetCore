using AutoMapper;
using FluentAssertions;
using MusicStore.Application.MusicOperations.Commands.CreateMusic;
using MusicStore.DbOperations;
using MusicStore.Entities;
using MusicStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Commands.CreateMusic
{
    public class CreateMusicCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMusicCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMusicNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var music = new Music() { Name = "TestMusic" };
            _context.Musics.Add(music);
            _context.SaveChanges();

            CreateMusicCommand command = new CreateMusicCommand(_context, _mapper);
            command.Model = new CreateMusicModel() { Name = music.Name };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Şarkı zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Music_ShouldBeCreated()
        {
            CreateMusicCommand command = new CreateMusicCommand(_context, _mapper);
            CreateMusicModel model = new CreateMusicModel()
            {
                Name = "Music1",
                Price = 5.75,
                SingerId = 1,
                GenreId = 1

            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var music = _context.Musics.SingleOrDefault(x => x.Name == model.Name);
            music.Should().NotBeNull();

        }
    }
}
