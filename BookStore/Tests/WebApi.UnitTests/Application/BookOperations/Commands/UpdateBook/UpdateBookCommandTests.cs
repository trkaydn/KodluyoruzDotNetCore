using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenBookNotFound_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = bookId;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeUpdated()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            UpdateBookModel model = new UpdateBookModel()
            {
                Title = "TestValidate",
                GenreId = 1
            };
            command.BookId = 1;
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            book.Should().NotBeNull();
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
