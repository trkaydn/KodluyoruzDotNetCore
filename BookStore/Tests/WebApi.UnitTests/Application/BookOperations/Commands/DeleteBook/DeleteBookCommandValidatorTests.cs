using FluentAssertions;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.UnitTests.TestSetup;
using Xunit;
namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenBookIdLessThanOne_Validator_ShouldBeReturnErrors(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
