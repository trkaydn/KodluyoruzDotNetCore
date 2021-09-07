using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenAuthorNotFound_InvalidOperationException_ShouldBeReturn(int authorId)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = authorId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek yazar bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorModel model = new UpdateAuthorModel()
            {
                Name="İsim",
                Surname="Soyisim",
                BirthDate=DateTime.Now.Date.AddYears(-2)
            };
            command.AuthorId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(x => x.Name == model.Name && x.Surname==model.Surname);
            author.Should().NotBeNull();
            author.Name.Should().Be(model.Name);
            author.Surname.Should().Be(model.Surname);
            author.BirthDate.Should().Be(model.BirthDate);
        }
    }
    
}
