using FluentAssertions;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenBookIdLessThanOne_Validator_ShouldBeReturnErrors(int bookId)
        {
            GetBookDetailQuery query = new GetBookDetailQuery(null,null);
            query.BookId = bookId;

            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
