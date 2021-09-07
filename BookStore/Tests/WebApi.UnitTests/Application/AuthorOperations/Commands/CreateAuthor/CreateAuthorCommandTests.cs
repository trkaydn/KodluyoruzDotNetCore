using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;


namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var author = new Author() { Name = "Faruk", Surname = "Aydın", BirthDate = new DateTime(1997, 03, 09) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel() { Name = author.Name, Surname = author.Surname, BirthDate = author.BirthDate };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeCreated()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            CreateAuthorModel model = new CreateAuthorModel()
            {
                Name = "Ali",
                Surname="Veli",
                BirthDate= new DateTime(1997, 03, 09),
             
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(x => x.Name == model.Name && x.Surname==model.Surname);
            author.Should().NotBeNull();

        }
    }
}
