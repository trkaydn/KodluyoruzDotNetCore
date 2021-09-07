using FluentAssertions;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;
        public UpdateBookCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenBookIdLessThanOne_Validator_ShouldBeReturnErrors(int bookId)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = bookId;
            UpdateBookModel model = new UpdateBookModel()
            {
                Title = "deneme",
                GenreId = 1
            };
            command.Model = model;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
 
            result.Errors.Count.Should().BeGreaterThan(0);
        }

       
    }
}
